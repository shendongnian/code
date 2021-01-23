        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void MenuItemContext(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) return;
            ToolStripMenuItem mID = (ToolStripMenuItem)sender;
            ContextMenu tsmiContext = new ContextMenu();
            MenuItem Item1 = new MenuItem();
            MenuItem Item2 = new MenuItem();
            Item1.Text = "Item1";
            Item2.Text = "Item2";
            tsmiContext.MenuItems.Add(Item1);
            tsmiContext.MenuItems.Add(Item2);
            Item1.Click += new EventHandler(Item1_Click);
            Item2.Click += new EventHandler(Item2_Click);
            hndPass = mID.Text;
            tsmiContext.Show(menuStrip1, menuStrip1.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
        }
        private String hndPass;
        void Item1_Click(object sender, EventArgs e)
        {
           MenuItem mID = (MenuItem)sender;
            MessageBox.Show("You clicked " + mID.Text + " in the context menu of " + hndPass);
        }
        void Item2_Click(object sender, EventArgs e)
        {
            MenuItem mID = (MenuItem)sender;
            MessageBox.Show("You clicked " + mID.Text + " in the context menu of " + hndPass); ;
        }
    }
