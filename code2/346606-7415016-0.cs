    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                // comment out the line below for the application to lag
                SetDoubleBuffered(dataGridView1);
    
    
                for (int i = 0; i < 10000; i++)
                {
                    dataSet1.DataTable1.AddDataTable1Row(GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString(),
                        GetRandomString());
                }
            }
    
            public static void SetDoubleBuffered(System.Windows.Forms.Control c)
            {
                //Taxes: Remote Desktop Connection and painting
                //http://blogs.msdn.com/oldnewthing/archive/2006/01/03/508694.aspx
                if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                    return;
    
                System.Reflection.PropertyInfo aProp =
                      typeof(System.Windows.Forms.Control).GetProperty(
                            "DoubleBuffered",
                            System.Reflection.BindingFlags.NonPublic |
                            System.Reflection.BindingFlags.Instance);
    
                aProp.SetValue(c, true, null);
            }
    
    
            private Random rand = new Random();
    
            private string validChars = "0123456789abcdefghijklmnopqurstuvwyz";
    
            private string GetRandomString()
            {
                StringBuilder builder = new StringBuilder();
    
                char[] c = new char[rand.Next(15,20)];
                for (int i = 0; i < c.Length; i++)
                {
                    c[i] = validChars[rand.Next(0, validChars.Length - 1)];
                }
    
                return new string(c);
            }
        }
    }
