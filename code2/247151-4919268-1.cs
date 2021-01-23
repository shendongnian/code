    string prodCode = context.Request.QueryString.Get("code");
    context.Response.ContentType = "image/gif";
    if (prodCode.Length > 0)
    {
      Barcode128 code128          = new Barcode128();
      code128.CodeType            = Barcode.CODE128;
      code128.ChecksumText        = true;
      code128.GenerateChecksum    = true;
      code128.StartStopText       = true;
      code128.Code                = prodCode;
      System.Drawing.Bitmap bm    = new System.Drawing.Bitmap(code128.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
      bm.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);            
    } 
