    public partial class Form1 : Form
    {
        DataGrid grid = new DataGrid();
        public Form1()
        {
            InitializeComponent();
            
            grid.DoubleClick += new EventHandler(grid_DoubleClick);
            grid.MouseDoubleClick += new MouseEventHandler(grid_MouseDoubleClick);            
            grid.Dock = DockStyle.Fill;
            this.Controls.Add(grid);
        }
        void grid_MouseDoubleClick(object sender, MouseEventArgs e)
        {            
        }
        void grid_DoubleClick(object sender, EventArgs e)
        {            
        }
    }
