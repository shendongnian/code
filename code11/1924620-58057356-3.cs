     public partial class ParentControl: UserControl
     {
    
        public ParentControl()
        {
            InitializeComponent();   
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            ChildForm child= new ChildForm ();
            child.Dock = DockStyle.Fill;
            child.CloseTabRequested += ChildForm_CloseTabRequested;
            TabPage tabNewChild= new TabPage("Child");
            tabNewChild.Controls.Add(child);
    
            tabDetails.TabPages.Add(tabNewChild);
            tabDetails.SelectedIndex = tabDetails.TabPages.IndexOf(tabNewChild);
        }
    
        void ChildForm_CloseTabRequested(object sender, EventArgs e)
        {
            CloseTab((ChildForm)sender);
        }
    
        void CloseTab(ChildForm requestingForm)
        {
            \\Close the selected tab
        }
    }
