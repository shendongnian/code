    public partial class mainForm : Form
    {
        private Bitmap image;
        private Rectangle imgRect;
        
        public mainForm()
        {
            InitializeComponent();
            BackColor = Color.Chartreuse;
            image = new Bitmap(@"C:\image.jpg");
            imgRect = new Rectangle(0,0,image.Width, image.Height);
        }
        
        private void main_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, 0, 0);
        }
        private void main_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && e.X < image.Width && e.Y < image.Height)
            {
               image.SetPixel(e.X, e.Y, Color.Magenta);//change pixel color;
               image.MakeTransparent(Color.Magenta);//Make image transparent
               Invalidate(imgRect);
            }
        }
    }
