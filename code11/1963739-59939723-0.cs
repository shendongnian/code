     // Copies and encodes pixel data to jpeg stream
     m_frame.Bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
     // Copies jpeg stream
     using (var outstream = new MemoryStream(stream.ToArray()))
     {
    
         BitmapImage bitmap = new BitmapImage();
         bitmap.BeginInit();
         //Copies jpeg stream again
         bitmap.StreamSource = new MemoryStream(stream.ToArray());
         bitmap.CacheOption = BitmapCacheOption.OnLoad;
         // Triggers jpeg stream decoding
         bitmap.EndInit();
         ui_canvas.Background = new ImageBrush(bitmap);
      }
