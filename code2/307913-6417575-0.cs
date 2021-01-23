            // declare the BufferManager somewhere. Check thread safety!
            BufferManager bm = BufferManager.CreateBufferManager(qqq, yyy);
            // wrap your current code to use the buffer manager
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (var bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                byte[] buffer = bm.TakeBuffer(yyy);
                try
                {
                  using (MemoryStream stream = new MemoryStream(buffer))
                  {
                     bitmap.Save(mss,ImageFormat.Gif);
                  }
                }
                finally
                {
                   bm.ReturnBuffer(buffer);
                }
           }
