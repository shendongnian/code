      WebClient MyWebClient = new WebClient();
        byte[] BytesImage = MyWebClient.DownloadData("http://www.google.com/intl/en_com/images/srpr/logo3w.png");
        System.IO.MemoryStream iStream= new System.IO.MemoryStream(BytesImage);
        System.Drawing.Bitmap b = new System.Drawing.Bitmap(iStream);
 
