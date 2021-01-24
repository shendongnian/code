    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.OleDb;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            String connParam = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\LL\Umpires.accdb;Persist Security Info=False";
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            OleDbDataAdapter dAdapter = new OleDbDataAdapter();
            BindingSource dataSource = new BindingSource();
    
            public Form1()
            {
                InitializeComponent();
    
                dAdapter = new OleDbDataAdapter("SELECT * FROM Rates", connParam);
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                dAdapter.Fill(dataTable);
                dataSource.DataSource = dataTable;
                dataGridView1.DataSource = dataSource;
                dataGridView1.Columns[0].ReadOnly=true;
                dataGridView1.CellFormatting +=
                    new System.Windows.Forms.DataGridViewCellFormattingEventHandler(
                    this.DGVRates_CellFormatting);
            }
    
            private void DGVRates_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if (this.dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "EffDate")
                    try
                    {
                        var EMIDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["effDateDataGridViewTextBoxColumn"].Value);
                        if (EMIDate <= DateTime.Today)
                        {
                            e.CellStyle.BackColor = Color.Red;
                        }
                    }
                    catch
                    {
                    }
            }
        }
    }
