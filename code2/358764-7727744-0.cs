    private void GetFilesFromDirectory(string PhysicalPath)
    {
        DirectoryInfo Dir = new DirectoryInfo(PhysicalPath);
        FileInfo[] FileList = Dir.GetFiles("*.*", SearchOption.AllDirectories);
        List<NewAddedFiles> list = new List<NewAddedFiles>();
          NewAddedFiles NewAddedFileItem = null;
        foreach (FileInfo FI in FileList)
        {
            //you need to create a new object at each iteration
            NewAddedFileItem = new NewAddedFiles();
            //Response.Write(FI.FullName);
            //Response.Write("<br />");
            string AbsoluteFilePath = FI.FullName;
            string RelativeFilePath = "~//" + AbsoluteFilePath.Replace(Request.ServerVariables["APPL_PHYSICAL_PATH"], String.Empty);
            NewAddedFileItem.FileName = FI.Name;
            NewAddedFileItem.FilePath = RelativeFilePath;
            NewAddedFileItem.FileCreationDate = FI.CreationTime;
            list.Add(NewAddedFileItem);
        }
          Repeater1.DataSource = list;
          Repeater1.DataBind();
    }
