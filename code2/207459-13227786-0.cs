    using System; using System.Collections.Generic; using
    System.ComponentModel; using System.Data; using System.Drawing; using
    System.Text; using System.Windows.Forms;
    
    namespace DateTimeConvert {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
              label1.Text= ConvDate_as_str(textBox1.Text);
            }
    
            public string ConvDate_as_str(string dateFormat)
            {
                try
                {
                    char[] ch = dateFormat.ToCharArray();
                    string[] sps = dateFormat.Split(' ');
                    string[] spd = sps[0].Split('.');
                    dateFormat = spd[0] + ":" + spd[1]+" "+sps[1];
                    DateTime dt = new DateTime();
                    dt = Convert.ToDateTime(dateFormat);
                    return dt.Hour.ToString("00") + dt.Minute.ToString("00");
                }
                catch (Exception ex)
                {
                    return "Enter Correct Format like <5.12 pm>";
                }
                
            }
    
    
            private void button2_Click(object sender, EventArgs e)
            {
               label2.Text = ConvDate_as_date(textBox2.Text);
            }
    
            public string ConvDate_as_date(string stringFormat)
            {
                try
                {
                    string hour = stringFormat.Substring(0, 2);
                    string min = stringFormat.Substring(2, 2);
                    DateTime dt = new DateTime();
                    dt = Convert.ToDateTime(hour+":"+min);
                    return String.Format("{0:t}", dt); ;
                }
                catch (Exception ex)
                {
                    return "Please Enter Correct format like <0559>";
                }
            }
        }
    }
