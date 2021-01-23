       int ix = Convert.ToInt32(v);
       MemoryStream ms = new MemoryStream(Query.imageList[ix]); // imagelist is created elsewhere
       System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
    
       context.Response.ContentType = "image/jpeg";
       //saving bitmap image
       returnImage.Save(context.Response.OutputStream,
       System.Drawing.Imaging.ImageFormat.Jpeg);
       returnImage.Dispose();
