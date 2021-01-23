    public void ReduceResolution(PdfReader reader, long quality) {
      int n = reader.XrefSize;
      for (int i = 0; i < n; i++) {
        PdfObject obj = reader.GetPdfObject(i);
        if (obj == null || !obj.IsStream()) {continue;}
    
        PdfDictionary dict = (PdfDictionary)PdfReader.GetPdfObject(obj);
        PdfName subType = (PdfName)PdfReader.GetPdfObject(
          dict.Get(PdfName.SUBTYPE)
        );
        if (!PdfName.IMAGE.Equals(subType)) {continue;}
    
        PRStream stream = (PRStream )obj;
        try {
          PdfImageObject image = new PdfImageObject(stream);
          PdfName filter = (PdfName) image.Get(PdfName.FILTER);
          if (
            PdfName.JBIG2DECODE.Equals(filter)
            || PdfName.JPXDECODE.Equals(filter)
            || PdfName.CCITTFAXDECODE.Equals(filter)
            || PdfName.FLATEDECODE.Equals(filter)
          ) continue;
         
          System.Drawing.Image img = image.GetDrawingImage();
          if (img == null) continue;
          
          var ll = image.GetImageBytesType();
          int width = img.Width;
          int height = img.Height;
          using (System.Drawing.Bitmap dotnetImg =
             new System.Drawing.Bitmap(img))
          {
            // set codec to jpeg type => jpeg index codec is "1"
            System.Drawing.Imaging.ImageCodecInfo codec =
            System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];
            // set parameters for image quality
            System.Drawing.Imaging.EncoderParameters eParams =
             new System.Drawing.Imaging.EncoderParameters(1);
            eParams.Param[0] =
             new System.Drawing.Imaging.EncoderParameter(
               System.Drawing.Imaging.Encoder.Quality, quality
            );
            using (MemoryStream msImg = new MemoryStream()) {
              dotnetImg.Save(msImg, codec, eParams);
              msImg.Position = 0;
              stream.SetData(msImg.ToArray());
              stream.SetData(
               msImg.ToArray(), false, PRStream.BEST_COMPRESSION
              );
              stream.Put(PdfName.TYPE, PdfName.XOBJECT);
              stream.Put(PdfName.SUBTYPE, PdfName.IMAGE);
              stream.Put(PdfName.FILTER, filter);
              stream.Put(PdfName.FILTER, PdfName.DCTDECODE);
              stream.Put(PdfName.WIDTH, new PdfNumber(width));
              stream.Put(PdfName.HEIGHT, new PdfNumber(height));
              stream.Put(PdfName.BITSPERCOMPONENT, new PdfNumber(8));
              stream.Put(PdfName.COLORSPACE, PdfName.DEVICERGB);
            }
          }
        }
        catch {
          // throw;
          // iText[Sharp] can't handle all image types...
        }
        finally {
    // may or may not help      
          reader.RemoveUnusedObjects();
        }
      }
    }
