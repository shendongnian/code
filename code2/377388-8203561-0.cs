    public partial class Form1 : Form
    {
      WebBrowser wb = new WebBrowser();
    
      public Form1()
      {
        InitializeComponent();
    
        wb.Height = 100;
        wb.Width = 100;
        wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
      }
    
      void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
      {
        Bitmap bmp = new Bitmap(100, 100);
        wb.DrawToBitmap(bmp, new Rectangle(wb.Location.X, wb.Location.Y, wb.Width, wb.Height));
    
        this.pictureBox1.BackgroundImage = bmp;
      }
    
    }
