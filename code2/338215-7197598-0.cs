    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.Office.Interop.Excel;
    
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
                String filename = "C:\\Path\\To\\Excel\\File\\file.xls";
                
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlApp.Visible = true;
                Workbook xlWkb = xlApp.Workbooks.Open(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Worksheet xlSh = xlWkb.Sheets[1] as Worksheet;
                Range xlRng = xlSh.UsedRange.get_Range("A1", Type.Missing).EntireRow;
                xlRng.Font.Bold = true;
                xlWkb.Save();
                xlApp.Quit();
                
                xlRng = null;
                xlSh = null;
                xlWkb = null;
                xlApp = null;
            }
        }
    }
