            var fileName = "filename.png";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "FolderName", fileName);
            MemoryStream memory = new MemoryStream();
            string stringToBeAdded = "String to be added in image";
            using (Bitmap bitmap = new Bitmap(filePath))
            {
                using(Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Brush brush = new SolidBrush(Color.Black);
                    Font font = new Font("Roboto", 90, FontStyle.Bold, GraphicsUnit.Pixel);
                    SizeF textSize = new SizeF();
                    textSize = graphics.MeasureString(stringToBeAdded, font);
                    Point position = new Point(bitmap.Width/2 - (int)textSize.Width/3, ((bitmap.Height/2)-20));
                    graphics.DrawString(stringToBeAdded, font, brush, position);
                    bitmap.Save(memory, ImageFormat.Png);
                    memory.Position = 0;
                    return File(memory.ToArray(), "image/png", fileName);
                }
