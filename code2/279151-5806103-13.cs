    public ActionResult GetImage1(int id)
    {
        const string alternativePicturePath = @"/Content/question_mark.jpg";
        MemoryStream stream;
        
        SubProductCategory4 z = db.SubProductCategory4.Where(k => k.SubProductCategoryFourID == id).FirstOrDefault();
        if (z != null && z.Image1 != null)
        {
            stream = new MemoryStream(z.Image1);
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
    public ActionResult GetImage2(int id)
    {
        const string alternativePicturePath = @"/Content/question_mark.jpg";
        MemoryStream stream;
        
        SubProductCategory4 z = db.SubProductCategory4.Where(k => k.SubProductCategoryFourID == id).FirstOrDefault();
        if (z != null && z.Image2 != null) // the difference is here
        {
            stream = new MemoryStream(z.Image2); // the difference is also here
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
