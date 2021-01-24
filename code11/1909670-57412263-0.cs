    public partial class LoggedInForm : Form
    {
        public LoggedInForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Creating a Bitmap
            Bitmap fooBitmap = new Bitmap(200, 200);
            //Filling the Bitmap with test text
            using (Graphics g = Graphics.FromImage(fooBitmap))
            {
                g.DrawString("this is a picture",
                    new Font(FontFamily.GenericSansSerif, 12)
                    , Brushes.Black, 0, 0); 
            }
            //Show the Bitmap on the PictureBox
            pictureBox1.Image = fooBitmap;
        }
    }
