    public partial class LoggedInForm : Form
    {
        public LoggedInForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Shows the Bitmap on the PictureBox
            pictureBox1.Image = NewProj.Properties.Resources.Logo;
        }
    }
