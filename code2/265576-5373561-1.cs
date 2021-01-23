    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
    
                Column1.DataSource = new int[] { 1, 2, 3 };
                Column1.DataPropertyName = "Number";
                dataGridView1.DataSource = new[] 
                { 
                    new { Number=1 },
                    new { Number=2 },
                    new { Number=3 },
                    new { Number=1 }
                };
            }
    
            private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if (e.ColumnIndex == Column1.Index && e.RowIndex == (dataGridView1.Rows.Count - 1))
                {
                    DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dataGridView1[e.ColumnIndex, e.RowIndex];
    
                    cell.Value = 2;
                    cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    cell.ReadOnly = true;
                }
            }
        }
    }
