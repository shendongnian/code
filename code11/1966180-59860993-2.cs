    using (ApplicationContext db = new ApplicationContext())
    {
        foreach(var file in files)
        {        
            using (MemoryStream ms = new MemoryStream())
            using(Image img = Image.FromFile(file))
            using(var imgRes = ResizeImage(img, ImageSettings.Width, ImageSettings.Height))
            {
                var imgRes = ResizeImage(img, ImageSettings.Width, ImageSettings.Height);
                MemoryStream memoryStream = new MemoryStream();
                img.Save(memoryStream, ImageFormat.Png);
                var label = Directory.GetParent(file).Name;
                var bytes = memoryStream.ToArray();
                db.Add(new ImageData { Image = bytes, Label = label }); 
            }
        }
    }
    
