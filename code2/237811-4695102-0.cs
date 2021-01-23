    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            var item = new ToolStripLabel();
            item.Image = Properties.Resources.SampleImage;
            item.Alignment = ToolStripItemAlignment.Right;
            item.Padding = new Padding(0, 0, 20, 0);
            menuStrip1.Items.Add(item);
        }
    }
