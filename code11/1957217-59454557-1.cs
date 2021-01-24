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
            static DataTable dt = new DataTable();
            public Form1()
            {
                InitializeComponent();
                dt.Columns.Add("SI No", typeof(int));
                dt.Columns.Add("Delete", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Path", typeof(string));
                dt.Rows.Add(new object[] { 1, "[]", "a", "C:\\a" });
                dt.Rows.Add(new object[] { 2, "[]", "b", "C:\\b" });
                dt.Rows.Add(new object[] { 3, "[]", "c", "C:\\c" });
                dt.Rows.Add(new object[] { 4, "[]", "d", "C:\\d" });
                dt.Rows.Add(new object[] { 5, "[]", "e", "C:\\e" });
                dt.Rows.Add(new object[] { 6, "[]", "f", "C:\\f" });
                dataGridView1.DataSource = dt;
                dataGridView1.CellClick +=new DataGridViewCellEventHandler(dataGridView1_CellClick);
            }
            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                int row = e.RowIndex;
                int col = e.ColumnIndex;
                if ((col == 1) && (dt.Rows.Count > 0))
                {
                    dt.Rows[row].Delete();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                }
                
            }
        }
    }
