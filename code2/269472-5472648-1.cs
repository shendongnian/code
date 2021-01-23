      using System.Drawing;
      using System.Drawing.Imaging;
      public Bitmap DownloadImage(string imageUrl)
      {
            try
            {
                  WebClient client = new WebClient();
                  using(Stream stream = client.OpenRead(imageUrl))
                  {
                        Bitmap bitmap = new Bitmap(stream);
                  }
            }
            catch(Exception)
            {
                  //todo: handle me
                  throw;
            }
            return bitmap
      }
