            var background = Brushes.Transparent;
            var bmp = Viewport3DHelper.RenderBitmap(viewport, 500, 500, background);
            BitmapEncoder encoder;
            string ext = Path.GetExtension(FileName);
            switch (ext.ToLower())
            {
                case ".png":
                    var png = new PngBitmapEncoder();
                    png.Frames.Add(BitmapFrame.Create(bmp));
                    encoder = png;
                    break;
                default:
                    throw new InvalidOperationException("Not supported file format.");
            }
            //using (Stream stm = File.Create(FileName))
            //{
            //    encoder.Save(stm);
            //}
            using (MemoryStream stream = new MemoryStream())
            {
                encoder.Save(stream);
                this.pictureBox1.Image = System.Drawing.Image.FromStream(stream);
            }
