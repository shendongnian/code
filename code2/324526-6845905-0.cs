     System.IO.MemoryStream ms = new System.IO.MemoryStream();
     pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
     byte[] ar = new byte[ms.Length];
     ms.Write(ar, 0, ar.Length);
           
