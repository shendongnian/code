    using System.Windows.Forms;
    using System.Drawing;
    
    namespace DatagridViewSelectAllCells_58842788
    {
        public partial class Form1 : Form
        {
            static Color originalColor;
            static int highlightedCol = -1;
            static DataGridView dataGridView1 = new DataGridView();
            public Form1()
            {
                InitializeComponent();
                Controls.Add(dataGridView1);
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                for (int i = 0; i < 10; i++)
                {
                    dataGridView1.Rows.Add($"col1_{i}", $"col2_{i}");
                }
                dataGridView1.CellMouseEnter += DataGridView1_CellMouseEnter;
                dataGridView1.CellMouseLeave += DataGridView1_CellMouseLeave;
    
                dataGridView1[1, 4].Style.BackColor = Color.DarkOliveGreen;
            }
    
            private void DataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
            {
                //WithCellStyle(sender, e, "Leave");
                WithDefaultStyle(sender, e, "Leave");
            }
    
            private void DataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
            {
                //WithCellStyle(sender, e, "Enter");
                WithDefaultStyle(sender, e, "Enter");
            }
    
    
            /*
             * to handle cells that have specific style attributes
             * like cell dataGridView1[1, 4]
             * there would be more to this to keep track of multiple different cell styles on the Leave side of thing
             * but that's up to you to handle if you have a need for it.
             */
            private static void WithCellStyle(object sender, DataGridViewCellEventArgs e, string eType)
            {
                switch (eType)
                {
                    case "Enter":
                        if (originalColor == null)
                        {
                            originalColor = ((Control)sender).BackColor;//store the color for leave event
                        }
                        highlightedCol = e.ColumnIndex;//set which column is highlighted for leave event
    
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataGridView1[highlightedCol, i].Style.BackColor = Color.Aquamarine;
                        }
                        break;
                    case "Leave":
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataGridView1[highlightedCol, i].Style.BackColor = originalColor;
                        }
                        break;
                    default:
                        break;
                }
            }
    
            /*
             * if you only have default styles
             */
            private static void WithDefaultStyle(object sender, DataGridViewCellEventArgs e, string eType)
            {
                switch (eType)
                {
                    case "Enter":
                        if (originalColor == null)
                        {
                            originalColor = ((Control)sender).BackColor;//store the color for leave event
                        }
                        highlightedCol = e.ColumnIndex;//set which column is highlighted for leave event
    
                        //change color of all the cells
                        dataGridView1.Columns[highlightedCol].DefaultCellStyle.BackColor = Color.Aquamarine;//set the new color
                        break;
                    case "Leave":
                        //per defaultstyle
                        dataGridView1.Columns[highlightedCol].DefaultCellStyle.BackColor = originalColor;
                        break;
                    default:
                        break;
                }
            }
        }
    }
