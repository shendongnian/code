    void BitmapCopy(System.Drawing.Bitmap source, string filename) {
      if (!String.IsNullOrEmpty(filename) && (source != null)) {
        string dirName = @"C:\Seva";
        if (!System.IO.Directory.Exists(dirName)) {
          dirName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
        string bmpFile = System.IO.Path.Combine(dirName, filename);
        System.Drawing.Bitmap bm = bitmapSourceToBitmap(source);
        try {
          bm.Save(bmpFile);
        } catch (ArgumentNullException ex) {
          Console.WriteLine(ex.Message);
        } catch (System.Runtime.InteropServices.ExternalException ex) {
          Console.WriteLine(ex.Message);
        }
      }
    }
