    if (this.fileUploader.PostedFile == null ||
        this.fileUploader.PostedFile.ContentLength < 1)
    {
       this.LabelError.Text = this.GetGlobalResourceObject("Messages", "NoFileToUpload")
                                  .ToString();
       return;
    }
    
    MyTableWithImageField i = new MyTableWithImageField();
    
    i.ImageData = this.fileUploader.FileBytes;
    
    command.CommandText = @"InsertMyTableWithImageField";
    command.CommandType = CommandType.StoredProcedure;
    
    command.Parameters.AddWithValue("@ImageData", i.ImageData);
