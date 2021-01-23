    var file = (HttpPostedFileBase)Request.Files[0];
    var buffer = new byte[file.ContentLength];
    file.InputStream.Read(buffer, 0, file.ContentLength);
    var root = HttpContext.Current.Server.MapPath(@"~/_temp");
    var temp_file_name = "somefilename";
    var path = Path.Combine(root, temp_file_name);
    using (var fs = new FileStream(path, FileMode.Create))
    {
        using (var br = new BinaryWriter(fs))
        {
            br.Write(buffer);
        }
    }
        
