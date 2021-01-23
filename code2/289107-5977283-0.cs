    public JsonResult GetJsonData()
    {
        var attachments = 
            (from a in ar.Attachments 
            select new { id = a.Id, filename = a.FileName }).ToArray(); 
    
        var result = new
            {
                comment = "Some string",
                attachments = new string[]{"/folder/file-1.jpg", "/folder/file-2.jpg"}            };
    
            return this.Json(result);
    }
