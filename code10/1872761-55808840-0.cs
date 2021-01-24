    [HttpPost]
    public string DownloadImagesFromLinkViaURL(ImagesViewModel model)
    {
        var RandomName = Guid.NewGuid().ToString("N").Substring(0, 12);
        var format = ImageFormat.Png.ToString().ToLower();
    
        var PathIMG = "https://SomeName.com/folder/" + RandomName + "." + format;
        if (model.ImageURL.StartsWith("data:image"))
        {
            string base64 = model.ImageURL.Substring(model.ImageURL.IndexOf(',') + 1);
            File.WriteAllBytes($@"c:\temp\{RandomName}.jpeg", Convert.FromBase64String(base64));
            ImageStore img = new ImageStore();
    
            img.ProducentVarenr = model.ImageName;
            img.ImageOrginalURL = model.ImageURL;
            img.ImageRandomName = RandomName;
            img.LinktilBillede = PathIMG;
            db.ImageStoreList.Add(img);
            db.SaveChanges();
            return "saved";
        }
        using (WebClient webClient = new WebClient())
        {
            try
            {
                byte[] data = Convert.FromBase64String(base64);
                var DL = webClient.DownloadData(base64);
    
                using (MemoryStream mem = new MemoryStream(DL))
                {
                    using (var content = Image.FromStream(mem))
                    {
                        content.Save(Path.Combine(Server.MapPath(PathIMG)));
                        ImageStore img = new ImageStore();
    
                        img.ProducentVarenr = model.ImageName;
                        img.ImageOrginalURL = model.ImageURL;
                        img.ImageRandomName = RandomName;
                        img.LinktilBillede = PathIMG;
                        db.ImageStoreList.Add(img);
                        db.SaveChanges();
                    }
                }
    
            }
            catch (ArgumentException)
            {
                return "content is not image";
            }
    
        }
        return "saved";
    }
