    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication44
    {
        public partial class Form1 : Form
        {
            DataTable m_dt = new DataTable();
            public Form1()
            {
                InitializeComponent();
                m_dgv.CellValueChanged += CellValueChangedHandler;
                m_dt.Columns.Add("Col_A", typeof(double));
                m_dt.Columns.Add("Col_B", typeof(string));
                m_dt.Rows.Add(new object[] { 1 });
                m_dgv.DataSource = m_dt;
            }
            private void CellValueChangedHandler(Object sender, DataGridViewCellEventArgs e)
            {
                DataGridView dgv = sender as DataGridView;
                DataGridViewCellEventArgs arg = e as DataGridViewCellEventArgs;
                int row = arg.RowIndex;
                int col = arg.ColumnIndex;
                if (row >= 0 && row == dgv.Rows.Count - 2) //new row already added to DGV
                {
                    if (row == 0)
                    {
                        if (col != 0)
                        {
                            dgv.Rows[row].Cells[0].Value = 1;
                        }
                    }
                    else
                    {
                        double temp = (double)dgv.Rows[row - 1].Cells[0].Value;
                        dgv.Rows[row].Cells[0].Value = temp + 1;
                    }
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                m_dt = m_dt.AsEnumerable().OrderBy(x => x.Field<string>("Col_B")).CopyToDataTable();
                m_dgv.DataSource = null;
                m_dgv.DataSource = m_dt;
            }
        }
    }
