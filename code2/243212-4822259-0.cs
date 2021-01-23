        private FileResult RenderImage()
        {   
            MemoryStream stream = new MemoryStream();
            var bitmap = CreateThumbnail();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            Byte[] bytes = stream.ToArray();
            return File(stream, "image/png");
        }
