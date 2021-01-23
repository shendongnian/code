    public partial class Form1 : Form
    {
        public Form1()
        {
            Xpcom.Initialize(@"C:\Users\esouza\Downloads\xulrunner"); //Tell where are XUL bin
            InitializeComponent();
            //geckoWebBrowser1 is an instance of GeckoWebBrowser control that I've dragged on the Form1
            geckoWebBrowser1.DocumentCompleted += new EventHandler(geckoWebBrowser1_DocumentCompleted);
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate("http://www.google.com");
        }
        void geckoWebBrowser1_DocumentCompleted(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(geckoWebBrowser1.Width, geckoWebBrowser1.Height);
            geckoWebBrowser1.DrawToBitmap(b, new Rectangle { X = 0, Y = 0, Width = 800, Height = 600 });
            b.Save("file.bmp");
        }
    }
