    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.ContextMenuStrip.Opening += new CancelEventHandler(ContextMenuStrip_Opening);
        }
        void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
   
