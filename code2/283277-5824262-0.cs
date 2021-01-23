    using ( WebClient webClient = new WebClient() ) 
    {
       using (Stream stream = webClient.OpenRead(imgeUri))
       {
          using (Bitmap bitmap = new Bitmap(stream))
          {
             stream.Flush();
             stream.Close();
             bitmap.Save(saveto);
          }
       }
    }
