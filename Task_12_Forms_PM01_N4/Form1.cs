using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_12_Forms_PM01_N4
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if(textBox1.Text != "")
				{
					DateTime setdata = DateTime.Parse(textBox1.Text);
					DataWork data = new DataWork(setdata);
					textBox2.Text = String.Format(data.LastDay(data.date));
					textBox3.Text = String.Format(data.NextDay(data.date));
					textBox4.Text = String.Format(Convert.ToString(data.DaysLeft(data.date)));
					if (data.LeapYear)
					{
						textBox5.Text = String.Format("высокосный");
					}
					else
					{
						textBox5.Text = String.Format("не высокосный");
					}
					int i = int.Parse(textBox6.Text);
					string str = data[i];
					textBox7.Text = String.Format(i + "-того дня");
					textBox8.Text = String.Format(str);
					textBox9.Text = String.Format(Convert.ToString(!data));
					if (data) textBox13.Text = String.Format("Эта дата является началом года.");
					else textBox13.Text = String.Format("Эта дата не является началом года");
					DataWork datac = textBox10.Text;
					if (data & datac) textBox11.Text = String.Format("равны");
					else textBox11.Text = String.Format("не равны");
					DataWork pre1;
					pre1 = (string)data;
					textBox12.Text = String.Format("Класс был преобразован из DateTime в string" + pre1);
					pre1 = (DataWork)data;
					textBox14.Text = String.Format("Класс был преобразован из string в DataTime" + pre1.DateValue);
				}
				else
				{
					DataWork data = new DataWork();
					textBox1.Text = String.Format(data.DateValue);
					textBox2.Text = String.Format(data.LastDay(data.date));
					textBox3.Text = String.Format(data.NextDay(data.date));
					textBox4.Text = string.Format(Convert.ToString(data.DaysLeft(data.date)));
					if (data.LeapYear)
					{
						textBox5.Text = String.Format("высокосный");
					}
					else
					{
						textBox5.Text = String.Format("не высокосный");
					}
					int i = int.Parse(textBox6.Text);
					string str = data[i];
					textBox7.Text = String.Format(i + "-того дня");
					textBox8.Text = String.Format(str);
					textBox9.Text = String.Format(Convert.ToString(!data));
					if (data) textBox13.Text = String.Format("Эта дата является началом года.");
					else textBox13.Text = String.Format("Эта дата не является началом года");
					DataWork datac = textBox10.Text;
					if (data & datac) textBox11.Text = String.Format("равны");
					else textBox11.Text = String.Format("не равны");
					DataWork pre1;
					pre1 = (string)data;
					textBox12.Text = String.Format("Класс был преобразован из DateTime в string" + pre1);
					pre1 = (DataWork)data;
					textBox14.Text = String.Format("Класс был преобразован из string в DataTime" + pre1.DateValue);
				}
				
			}
			catch (FormatException)
			{
				MessageBox.Show("Неверный ввод данных", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch
			{
				MessageBox.Show("Неизвестная ошибка", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}

	class DataWork
	{
		public DateTime date;

		public DataWork()
		{
			date = new DateTime(2009, 1, 1);
		}

		public DataWork(DateTime date)
		{
			this.date = date;
		}

		public string LastDay(DateTime date)
		{
			DateTime ldate = date.AddDays(-1);
			return ldate.ToShortDateString();
		}

		public string NextDay(DateTime date)
		{
			DateTime ndate = date.AddDays(1);
			return ndate.ToShortDateString();
		}

		public int DaysLeft(DateTime date)
		{
			int dLeft = DateTime.DaysInMonth(date.Year, date.Month) - date.Day;
			return dLeft;
		}

		public string DateValue
		{
			get
			{
				return date.ToShortDateString();
			}
			set
			{
				date = DateTime.Parse(value);
			}
		}

		public bool LeapYear
		{
			get
			{
				if (date.Year % 4 == 0)
					return true;
				else
					return false;
			}
		}

		public string this[int index]
		{
			get
			{
				return date.AddDays(index).ToShortDateString();
			}
		}

		public static bool operator !(DataWork dataWork)
		{
			DateTime d2 = dataWork.date;
			DateTime d1 = dataWork.date.AddDays(1);
			if (d2.Month == d1.Month) return true;
			else return false;
		}

		private bool tf()
		{
			if (date.Day == 1 && date.Month == 1) return true;
			else return false;
		}

		public static bool operator true(DataWork datawork)
		{
			return datawork.tf();
		}
		public static bool operator false(DataWork datawork)
		{
			return !datawork.tf();
		}

		public static bool operator &(DataWork dataWork, DataWork datawork1)
		{
			if (dataWork.date == datawork1.date) return true;
			else return false;
		}

		public static implicit operator string(DataWork data)
		{
			int Year = data.date.Year, Month = data.date.Month, Day = data.date.Day;
			string str1 = Day + "." + Month + "." + Year;
			return str1;
		}

		public static implicit operator DataWork(string data)
		{
			DataWork dataWork = new DataWork(Convert.ToDateTime(data));
			return dataWork;
		}

	}
}
