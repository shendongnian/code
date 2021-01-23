    public partial class Form1 : Form
    {
        public Form1()
        {
            Xpcom.Initialize(@"C:\Users\esouza\Downloads\xulrunner"); //Tell where are XUL bin
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate("http://www.google.com");
            geckoWebBrowser1.Navigated += new GeckoNavigatedEventHandler(geckoWebBrowser1_Navigated);
        }
    
        void geckoWebBrowser1_Navigated(object sender, GeckoNavigatedEventArgs e)
        {
            Bitmap b = new Bitmap(geckoWebBrowser1.Width, geckoWebBrowser1.Height);
            geckoWebBrowser1.DrawToBitmap(b, geckoWebBrowser1.Bounds);
            b.Save("file.bmp");
        }
    }
