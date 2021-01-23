    src = Request.QueryString["imgsrc"];//src = "images/file 15.jpeg";
    
    string tempPath = Server.MapPath(src);
    
    Debug.Assert(System.IO.File.Exists(tempPath);
    
    System.Drawing.Image image = System.Drawing.Image.FromFile(tempPath);
