    using System.Windows.Forms;
    
    namespace DatagridViewSelectAllCells_58842788
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                for (int i = 0; i < 10; i++)
                {
                    dataGridView1.Rows.Add($"col1_{i}", $"col2_{i}");
                }
                dataGridView1.CellMouseEnter += DataGridView1_CellMouseEnter;
            }
    
            private void DataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == -1)//don't do anything if the rowheader is being hovered
                {
                    return;
                }
                if (dataGridView1.SelectedCells.Count > 1 && e.ColumnIndex == dataGridView1.SelectedCells[0].ColumnIndex)//don't do anything if the column is already selected
                {
                    return;
                }
                dataGridView1.ClearSelection();//clear the current selection
    
                //select all the cells in that hovered column
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1[e.ColumnIndex, i].Selected = true;
                }
            }
        }
    }
