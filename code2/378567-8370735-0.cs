    public class CustomListDropDown : ToolStripDropDown
    {
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private System.ComponentModel.IContainer components;
    
        public ListBox ListBox { get; private set; }
        public CustomListDropDown()
        {
            InitializeComponent();
            this.ListBox = new ListBox() { Width = 200, Height = 600 };
            this.Items.Add(new ToolStripControlHost(this.ListBox));
            this.ListBox.ContextMenuStrip = contextMenuStrip1;
            this.ListBox.MouseDown += new MouseEventHandler(ListBox_MouseDown);
            contextMenuStrip1.Closing += new ToolStripDropDownClosingEventHandler(contextMenuStrip1_Closing);
            //add sample items
            this.ListBox.Items.Add("Item1");
            this.ListBox.Items.Add("Item2");
            this.ListBox.Items.Add("Item3");
            this.ListBox.Items.Add("Item4");
        }
        void contextMenuStrip1_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            this.Close();
            this.AutoClose = true;
        }
        void ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.AutoClose = false;
            this.ListBox.SelectedIndex = this.ListBox.IndexFromPoint(e.Location);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // contextMenuStrip1.ContextMenuStrip
            // 
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // CustomListDropDown
            // 
            this.Size = new System.Drawing.Size(2, 4);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
