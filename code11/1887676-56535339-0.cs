    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(@"C:\Users\Ryan\Desktop\Coding\DOT.NET\Samples C#\Excel Workbook - Save Each Sheet as a CSV File\Book1.xlsx");
                xlApp.Visible = true;
                foreach (Excel.Worksheet sht in xlWorkBook.Worksheets)
                {
                    sht.Select();
                    xlWorkBook.SaveAs(string.Format("{0}{1}.csv", @"C:\Users\Ryan\Desktop\Coding\DOT.NET\Samples C#\Excel Workbook - Save Each Sheet as a CSV File to CSV\", sht.Name), Excel.XlFileFormat.xlCSV, Excel.XlSaveAsAccessMode.xlNoChange);
                    
                }
                xlWorkBook.Close(false);
    
            }
    
        }
    }
