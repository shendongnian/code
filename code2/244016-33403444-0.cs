     byte[] imgbytes;    
     using (MemoryStream stream = new MemoryStream())
     {
            cropped.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            imgbytes = stream.ToArray();
     }
     <img src="@String.Format("data:image/png;base64,{0}", Convert.ToBase64String(imgbytes))" />
