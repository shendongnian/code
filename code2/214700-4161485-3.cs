    public partial class MainWindow : Window
    {
      public MainWindow()
      {
        InitializeComponent();
        SavePhoto("http://www.google.ca/intl/en_com/images/srpr/logo1w.png");
      }
      public void SavePhoto(string istrImagePath)
      {
        BitmapImage objImage = new BitmapImage(new Uri(istrImagePath, UriKind.RelativeOrAbsolute));
      
        objImage.DownloadCompleted += objImage_DownloadCompleted;
      }
      private void objImage_DownloadCompleted(object sender, EventArgs e)
      {
        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        Guid photoID = System.Guid.NewGuid();
        String photolocation = photoID.ToString() + ".jpg";  //file name 
        encoder.Frames.Add(BitmapFrame.Create((BitmapImage)sender));
        using (var filestream = new FileStream(photolocation, FileMode.Create))
          encoder.Save(filestream);
      } 
    }
