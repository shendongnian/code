    Int32 RecentGenerateID = 34;//Assign ID that you are getting from DB
    if(FileUpload1.HasFile)
    {
    FileUpload1.SaveAs(Server.MapPath("~/FolderName/" + RecentGenerateID.ToString() + System.IO.Path.GetExtension(FileUpload1.FileName));
    }
