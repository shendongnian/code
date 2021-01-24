    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace Office
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;
            var excelBook = excelApp.Workbooks.Open(@"C:\excelFile.xls");
            var excelSheet = (Excel.Worksheet)excelBook.Sheets[1];
            var lastrowR = excelSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
            var lastrowC = excelSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column;
            for (int i = 1; i <= lastrowC; i++)
            {
                dataGridView1.Columns.Add("Column"+i.ToString(), i.ToString());
            }
            for (int j = 1; j <= lastrowR; j++)
            {
                dataGridView1.Rows.Add();
            }
            for (int x=2; x <= 6; x++)
            {
                for (int y = 15; y <= 16; y++)
                {
                    dataGridView1.Rows[y-14].Cells[x-1].Value = excelSheet.Cells[y, x].Value.ToString();
                }
            }
            excelBook.Close();
            excelApp.Quit();
        }
    }
    }
