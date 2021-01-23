    TestDBDataContext context1 = new TestDBDataContext();
    int id;
    if(int.TryParse(Request.QueryString["id"], out id))
    {
      var r = (from a in context1.ImageTables where a.Id == 8 select a).FirstOrDefault();
      if(r != null)
      {
        Response.ContentType = r.ContentType;
        Response.BinaryWrite(r.FileImage.ToArray());
        return;
      }
    }
    //code to handle 404 not found for no such image here (send error message or Server.Transfer to error page, etc.
