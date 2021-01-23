    protected void OnUploadComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        if (UploadResume.HasFile)
        {
            // do something with uploaded file, e.g. save
            String path = MapPath("yourpath") + Path.GetFileName(e.FileName);
            UploadResume.SaveAs(path);
        }
        else
        {
            // error
        }
    }
