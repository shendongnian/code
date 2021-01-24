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
     
                foreach (FileInfo file in Files)
                {
                    string name = info.Name;
                    list.Add(file.Name);
                    string[] lines = System.IO.File.ReadAllLines(folder + file,
                                                                Encoding.GetEncoding("windows-1254"));
                    values.AddRange(MultiColumns(lines));
                }
            }
            private List<double> MultiColumns(String[] strs)
            {
                double col1Max = 0;
                double col2Max = 0;
                double col3Max = 0;
                var list = new List<Double>();
                var format = new NumberFormatInfo();
                format.NegativeSign = "-";
                format.NumberNegativePattern = 1;
                format.NumberDecimalSeparator = ".";
                foreach (var row in strs)
                {
                    var rowElements = row.Split(',');
                    Double temp1 = 0;
                    Double temp2 = 0;
                    Double temp3 = 0;
                    Double.TryParse(rowElements[0], NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, format, out temp1);
                    Double.TryParse(rowElements[1], NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, format, out temp2);
                    Double.TryParse(rowElements[2], NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, format, out temp3);
                    col1Max = getMax(col1Max, temp1);
                    col2Max = getMax(col2Max, temp2);
                    col3Max = getMax(col3Max, temp3);
                }
                list.Add(col1Max);
                list.Add(col2Max);
                list.Add(col3Max);
                return list;
            }
            private double getMax(double colMax, double temp)
            {
                //Math.Abs(colMax);
                if (temp < 0)
                {
                    temp *= -1;
                }
                if (temp > colMax)
                {
                    colMax = temp;
                }
                return colMax;
            }
        }
    }
