    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("col1", "col1");
            dataGridView1.Columns[0].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns.Add("col2", "col2");
            dataGridView1.Columns.Add("col3", "col3");
            
            dataGridView1.Rows.Add();
            dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(dataGridView1_ColumnWidthChanged);              
        }
        void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Index == 0)
            {
                // We need to truncate everything again when the width changes
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    RightTruncateText(row.Cells[0]);
                }
            }
        }
        void RightTruncateText(DataGridViewCell cell)
        {                        
            // check if the content is too long:
            using (Graphics g = Graphics.FromHwnd(this.Handle))
            {
                SizeF size = g.MeasureString((string)cell.Tag, dataGridView1.Font); // NOTE: using the tag
                if (size.Width > cell.Size.Width)
                {
                    StringBuilder truncated = new StringBuilder((string)cell.Tag);
                    truncated.Insert(0, "...");
                    // Truncate the string until small enough (NOTE: not optimized in any way!)                        
                    while (size.Width > cell.Size.Width)
                    {
                        truncated.Remove(3, 1);
                        size = g.MeasureString(truncated.ToString(), dataGridView1.Font);
                    }
                    cell.Value = truncated.ToString();
                }
                else
                {
                    cell.Value = cell.Tag;
                }
            }
        }
        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                // Save the value in the tag but show the truncated value
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Tag = cell.Value; // Saving the actual state
                RightTruncateText(cell);
            }
        }
    }
