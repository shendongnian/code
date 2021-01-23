    string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
    AsyncFileUpload1.SaveAs(Server.MapPath("./") + "abc.jpeg");
    System.Drawing.Image NewImage = null;
    //File handle seems not get released right away here.
    using(System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(Server.MapPath("./") + "abc.jpeg"))
        NewImage = FullsizeImage.GetThumbnailImage(60, 60, null, IntPtr.Zero);
    using(NewImage)
        NewImage.Save(Server.MapPath("./") + "abc.jpeg");
