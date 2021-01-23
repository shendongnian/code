    public partial class Form1 : Form
    {
        private int initialX;
        public Form1()
        {
            InitializeComponent();
            initialX = this.Location.X;
        }
        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (this.Location.X != initialX)
                this.Location = new Point(initialX, this.Location.Y);
        }
    }
