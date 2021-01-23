    public partial class Form1 : Form
    {
        DataGridView dataGrid;
        ContextMenuStrip contextMenuStrip;        
        public Form1()
        {
            InitializeComponent();
            dataGrid = new DataGridView();
            Controls.Add(dataGrid);
            dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            //dataGrid.ColumnHeaderMouseClick += ColumnHeaderMouseClick;
            dataGrid.MouseDown += MouseDown;
            dataGrid.DataSource = new Dictionary<string, string>().ToList();
            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("foo");
            contextMenuStrip.Items.Add("bar");
        }
        private void ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip.Show(PointToScreen(e.Location));
            }
        }
        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (dataGrid.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader)
                {
                    contextMenuStrip.Show(dataGrid.PointToScreen(e.Location));
                }
            }
        }
    }
