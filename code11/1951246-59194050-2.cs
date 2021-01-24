    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Globalization;
    namespace WindowsFormsApplication4
    {
        public partial class Form1 : Form
        {
     
            public Form1()
            {
                InitializeComponent();
                
            }
            private void button1_Click(object sender, EventArgs e)
            {
                string folder = @"D:\Desktop\..";
                ReadTextFile readTextFile = new ReadTextFile(folder);
                List<double> absolute = readTextFile.values.Select(x => Math.Abs(x)).ToList();
                double max = readTextFile.values.OrderByDescending(x => x).FirstOrDefault();
            }
        }
        public class ReadTextFile
        {
            public List<string> list { get; set; }
            public List<Double> values { get; set; }
            public ReadTextFile(string folder)
            {
                DirectoryInfo info = new DirectoryInfo(folder);
                FileInfo[] Files = info.GetFiles("*.txt");
                list = new List<string>();
                values = new List<Double>();
                NumberFormatInfo format = new NumberFormatInfo();
                format.NegativeSign = "-";
                format.NumberNegativePattern = 1;
                format.NumberDecimalSeparator = ".";
     
                foreach (FileInfo file in Files)
                {
                    string name = info.Name;
                    list.Add(file.Name);
                    string[] lines = System.IO.File.ReadAllLines(folder + file,
                                                                Encoding.GetEncoding("windows-1254"));
                    values.AddRange(lines.SelectMany(x => x.Split(',').Select(y => Double.Parse(y, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, format))));
                }
            }
        }
    }
