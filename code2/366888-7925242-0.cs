    public FileContentResult GetImage(int ID)
    {
        ClassYouHave hyperLink;
        // .. your code to load the data you've shown above
        using (MemoryStream ms = new MemoryStream())
        {
            hyperLink.Image.Save(ms, ImageFormat.Jpeg);
            return File(ms, "image/" + hyperLink.ImageType);
        }
    }
