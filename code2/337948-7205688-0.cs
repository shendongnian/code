    protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e) 
    { 
        if (DetailsView1.CurrentMode == DetailsViewMode.Insert) 
        { 
            if (Session["ProjectId"] != null) 
            { 
                int Projectid = Convert.ToInt32(Session["ProjectId"]); 
                string Description = (DetailsView1.FindControl("RadEditor1") as RadEditor).Content; 
                RadAsyncUpload radAsyncUpload = DetailsView1.FindControl("RadAsyncUpload1") as RadAsyncUpload; 
     
                UploadedFile file = radAsyncUpload.UploadedFiles[0]; 
                string s = file.FileName; 
                string path = System.IO.Path.GetFileName(s); 
     
     
                string Contenttype = radAsyncUpload.UploadedFiles[0].ContentType; 
                int fileSize = radAsyncUpload.UploadedFiles[0].ContentLength; 
                float length = float.Parse(fileSize.ToString()); 
                byte[] fileData = new byte[file.InputStream.Length]; 
                file.InputStream.Read(fileData, 0, (int)file.InputStream.Length); 
     
     
                        ProTrakEntities objEntity = new ProTrakEntities(); 
                        ProjectFile objFile = new ProjectFile(); 
                        objFile.ProjectId = Projectid; 
                        objFile.FileName = s; 
                        objFile.FileType = Contenttype; 
                        objFile.FileSize = length; 
                        objFile.CreatedBy = "admin"; 
                        objFile.CreatedDate = DateTime.Now; 
                        objFile.Description = Description; 
                        objFile.FileData = fileData; 
                        objEntity.AddToProjectFiles(objFile); 
                        objEntity.SaveChanges(); 
     
            } 
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly); 
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('navigateToInserted');", true); 
     
    radAsyncUpload.UploadedFiles[0].SaveAs(Server.MapPath("Uploads/") + path); 
     
        } 
    }
