    protected void Button1_Click(object sender, EventArgs e)
        {
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                string SaveLocation = Server.MapPath("~/upload/");
                try
                {
                    FileUpload1.PostedFile.SaveAs(SaveLocation+fn +ext);
                    FileUploadStatus.Text = "The file has been uploaded.";
                }
                catch (Exception ex)
                {
                    FileUploadStatus.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                FileUploadStatus.Text = "Please select a file to upload.";
            }
        }
