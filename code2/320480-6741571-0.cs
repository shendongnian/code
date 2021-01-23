    WebClient webClient = new WebClient();
    using (Stream stream = webClient.OpenRead(imgeUri))
    {
       using (Bitmap bitmap = new Bitmap(stream))
       {
          stream.Flush(); // not really necessary, but doesnt hurt
          stream.Close();
          try
          {
             // now, lets save to a memory stream and
             // return the byte[]
             MemoryStream ms = new MemoryStream();
             
             // doesnt have to be a Png, could be whatever you want (jpb, bmp, etc.)
             bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
             return ms.GetBuffer()
          }
          catch (Exception err)
          {
             Console.WriteLine("{0}\t\tError: {1}", id, err.Message);
          }
       }
    }
