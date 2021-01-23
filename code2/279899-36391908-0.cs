    YourPanel.AutoSize = true;
            
               
            int width = YourPanel.Size.Width;
            int height = YourPanel.Size.Height;
            Bitmap bm = new Bitmap(width, height);
            YourPanel.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
            string outputFileName = @"C:\YourDirectory/myimage.bmp";
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    bm.Save(memory, ImageFormat.Bmp);
                    Clipboard.SetImage(bm);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            YourPanel.AutoSize = false;
