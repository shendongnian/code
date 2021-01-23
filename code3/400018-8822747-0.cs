    class loadimage: ihttphandler
    {
       public void Process(HttpContext context)
       {
            var id = context.Request["id"];
            var row = GetImageFromDb(id);
            var response = context.Response;
            response.AddHeader("content-disposition", "attachment; filename=" + row["anem of image"]);
            response.ContentType = row["mime type"].ToString(); //png or gif etc.
            response.BinaryWrite((byte[])row["image blob"]);
       }
       public bool Reuse { get {return true; } }
    }
