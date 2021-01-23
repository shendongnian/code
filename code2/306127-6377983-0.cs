    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BindingList<User> users = new BindingList<User>();
            users.Add(new User(){Name = "Fred", Included = "False", Title="Mr"});
            users.Add(new User(){Name = "Sue", Included = "False", Title="Dr"});
            users.Add(new User(){Name = "Jack", Included = "False", Title="Mr"});
            dataGridView1.DataSource = users;
        }
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[hit.RowIndex].Selected = true;
                contextMenuStrip1.Show(this.dataGridView1, new Point(e.X, e.Y));
            }
        }
        private void includeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dataGridView1.SelectedRows[0].Cells["Included"].Value = "Included";
        }
    }
    public class User
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Included { get; set; }
    }
