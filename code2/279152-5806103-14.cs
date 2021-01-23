    public ActionResult GetImage(int id, int? imageNum)
    {
        imageNum = imageNum ?? 0;
        const string alternativePicturePath = @"/Content/question_mark.jpg";
        MemoryStream stream;
        
        SubProductCategory4 z = db.SubProductCategory4.Where(k => k.SubProductCategoryFourID == id).FirstOrDefault();
        byte[] imageData = null;
        if (z != null)
        {
            imageData = imageNum == 1 ? z.Image1 : imageNum == 2 ? z.Image2 : null;
        }
        if (imageData != null)
        {
            stream = new MemoryStream(imageData);
        }
        else
        {
            var path = Server.MapPath(alternativePicturePath);
            stream = new MemoryStream();
            var imagex = new System.Drawing.Bitmap(path);
            imagex.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            stream.Seek(0, SeekOrigin.Begin);
        }
        return new FileStreamResult(stream,"image/jpg");
    }
