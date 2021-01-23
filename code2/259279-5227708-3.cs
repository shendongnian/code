    public partial class Form1 : Form
    {
        private readonly Camera camera = new Camera();
        public Form1()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = camera;
        }
        private void Button1Click(object sender, System.EventArgs e)
        {
            camera.Configuration = new Configuration2();
            UpdatePropertyGrid();
        }
        private void Button2Click(object sender, System.EventArgs e)
        {
            camera.Configuration = new Configuration1();
            UpdatePropertyGrid();
        }
        private void UpdatePropertyGrid()
        {
            propertyGrid1.Refresh();
            propertyGrid1.ExpandAllGridItems();
        }
    }
