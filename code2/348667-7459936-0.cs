    using (Image image = ...)
    {
        var imagesFolder = Server.MapPath("~/Content/UploadedImages");
        var filename = Path.Combine(imagesFolder, id, file.FileName.Replace(" ",""));
        image.Save(filename);
    }
