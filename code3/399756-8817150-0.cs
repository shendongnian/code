     protected void Page_Load(object sender, EventArgs e)
    {  
           
        FileStream fs = File.OpenRead(Server.MapPath("~/imgName.jpg"));
        byte[] buffer = new byte[(int)fs.Length];
        fs.Read(buffer, 0, (int)fs.Length);
        fs.Close();
        SetResponse("imgName");
        HttpContext.Current.Response.BinaryWrite(buffer);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.Close();
    }
    
    private static void SetResponse(string fileName)
    {
        string attachment = "attachment; filename=" + fileName + ".jpg";
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", attachment);
        HttpContext.Current.Response.ContentType = "image/jpeg";
        HttpContext.Current.Response.AddHeader("Pragma", "public");
    }
