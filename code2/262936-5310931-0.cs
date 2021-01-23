    string _fileName;
    
    string _path = /*some user specific path*/ + "FileDir/" + name;
    
    System.IO.FileInfo _file = new System.IO.FileInfo(_path);
    
    if (_file.Exists)
    
    {
    	Response.Clear();
    	Response.AddHeader("Content-Disposition", "attachment; filename=" + _file.Name);
    	Response.AddHeader("Content-Length", _file.Length.ToString());
    	Response.ContentType = "application/octet-stream";
    	Response.WriteFile(_file.FullName);
    	Response.End();
    }
