    public partial class Form2 : Form
    {
        Image picQr;
        public Form2(Image qrCodeimage)
        {
            InitializeComponent();
            picQr = qrCodeimage;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = picQr;
        }
    }
}
