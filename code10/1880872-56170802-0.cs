    public ActionResult Savedata(HttpPostedFileBase Image)
    {
        SaveImage obj = new SaveImage();
        string result;
    
        if (Image != null)
        {
            obj.ImageName = Image.FileName;
    
            string imageFolder = "~/DemoImages/";
            var path = Path.GetFileNameWithoutExtension(Image.FileName) + DateTime.Now.ToString("ddMMyyhhmmss") + Path.GetExtension(Image.FileName);
            result = path.Replace(" ", string.Empty);
            var serversavepath = Path.Combine(Server.MapPath(imageFolder) + result);
            Image.SaveAs(serversavepath);                
    
            obj.ImageName = imageFolder + result;
            entity.SaveImages.Add(obj);
            entity.SaveChanges();                
        }
    
        return Content("<script>alert('Data Successfully Submitted');location.href='../Home/Index';</script>"); 
    }
