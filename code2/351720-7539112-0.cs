    //HANDLE EACH FILE IN THE REQUEST
    foreach (string key in context.Request.Files)
    {
      HttpPostedFile item = context.Request.Files[key];
      item.SaveAs(context.Server.MapPath("~/Temp/" + item.FileName));
      context.Response.Write("File uploaded");
    }
