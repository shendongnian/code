      using (Graphics g = Graphics.FromImage(image))
      using (Image i = newImage.GetThumbnailImage(10, 10, null, new IntPtr()))
      {
          g.DrawImage(i, 3, 3, 10, 10);
      }
