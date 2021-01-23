            Bitmap bmpImage = new Bitmap(width, height);
            Graphics gr = Graphics.FromImage(bmpImage);
            //Draw using gr here
            //stream to the client
            Response.ContentType = "image/png";
            //write to memory stream first, png can only be written to seekable stream
            using(MemoryStream memStream = new MemoryStream())
            {
              bmpImage.Save(memStream, ImageFormat.Png);
              memStream.WriteTo(Response.OutputStream);
            }
            bmpImage.Dispose();
