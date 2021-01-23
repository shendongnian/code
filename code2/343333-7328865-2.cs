    public partial class TabPageEntry_Form2 : Form
    {
        public delegate void TreeViewHander();
        public event TreeViewHander TreeView;
        public TabPageEntry_Form2()
        {
            InitializeComponent();
        }
    
    
    
        private void button2_Click(object sender, EventArgs e)
        {
            if (TreeView) 
            {
                TreeView();
            }
        }
....
        
        // Form1 
        TabPageEntry_Form2 form2 = new TabPageEntry_Form2 ();
        form2.TreeView += treeview;
