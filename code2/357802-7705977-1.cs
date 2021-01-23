    public void ImageFileSelected(object sender, DirectEventArgs e) {
        if (this.FileUploadField1.HasFile) {
            // save file here
            X.Msg.Show(new MessageBoxConfig {
               Buttons = MessageBox.Button.OK,
               Icon = MessageBox.Icon.INFO,
               Title = "Success",
               Message = string.Format(tpl, this.FileUploadField1.PostedFile.FileName,  
               this.FileUploadField1.PostedFile.ContentLength)
            });
        }
    }
