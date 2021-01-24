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
                dt.Columns.Add("Delete", typeof(Boolean));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Path", typeof(string));
                dt.Rows.Add(new object[] { 1, false, "a", "C:\\a" });
                dt.Rows.Add(new object[] { 2, false, "b", "C:\\b" });
                dt.Rows.Add(new object[] { 3, false, "c", "C:\\c" });
                dt.Rows.Add(new object[] { 4, false, "d", "C:\\d" });
                dt.Rows.Add(new object[] { 5, false, "e", "C:\\e" });
                dt.Rows.Add(new object[] { 6, false, "f", "C:\\f" });
                dataGridView1.DataSource = dt;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if ((Boolean)(dt.Rows[i][1]) == true)
                    {
                        dt.Rows[i].Delete();
                    }
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }
        }
    }
