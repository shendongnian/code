    [HttpPost]
    [Route("Fileretrive")]
    public IActionResult retrive(string filename)
    {
        //var ctx = HttpContext.Current;
        var root = HttpContext.Current.Server.MapPath("~/Photos");
        var tempath = Path.Combine(root,filename);
        Directory.GetFiles(tempath);
        byte[] byteArray = null;
        byteArray = System.IO.File.ReadAllBytes(tempath);
        // check your mime type, and set your unique file name. maybe use DateTime for your file name
        return File(byteArray , "image/jpeg", $"{DateTime.Now.ToString("ddMMMyyyy")}.jpeg"); 
    
    }
