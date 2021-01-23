    namespace WindowsFormsApplication4
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                BindingList<User> users = new BindingList<User>{
                      new User{Name = "John", Address="Home Street", Title="Mr."},
                      new User{Name = "Sally", Address="Home Street", Title="Mrs."}
                };
    
                contextMenuStrip1.AutoClose = true;           
                dataGridView1.DataSource = users;
    
                dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridView1_DataBindingComplete);
            }
    
            void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
            {
    
                foreach (DataGridViewColumn gridViewColumn in this.dataGridView1.Columns)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Name = gridViewColumn.Name;
                    item.Text = gridViewColumn.Name;
                    item.Checked = true;
                    item.CheckOnClick = true;
                    item.CheckedChanged += new EventHandler(item_CheckedChanged);
                    contextMenuStrip1.Items.Add(item);
                }
    
                foreach (DataGridViewColumn gridViewColumn in this.dataGridView1.Columns)
                {
                    gridViewColumn.HeaderCell.ContextMenuStrip = contextMenuStrip1;
                }
    
            }
    
            void item_CheckedChanged(object sender, EventArgs e)
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
    
                if (item != null)
                {
                    dataGridView1.Columns[item.Name].Visible = item.Checked;
                }
            }
        }
    
        public class User
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string Title { get; set; }
        }
    
    }
