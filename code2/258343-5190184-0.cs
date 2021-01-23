      using (Stream memStream = new MemoryStream(bytes))
      {
        using (Image img = System.Drawing.Image.FromStream(memStream))
        {
          int width = img.Width;
          int height = img.Height;
        }
      }
    
