    protected void btnFileUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (file_upload.HasFile && file_upload.PostedFiles.All(x => x.ContentType == "image/jpeg" && x.ContentLength < 102400))
            {
                foreach (var file in file_upload.PostedFiles)
                {
                    file_upload.SaveAs(Server.MapPath("~/") + Path.GetFileName(file.FileName));
                }
                lblUploadStatus.Text = "File(s) uploaded successfully.";
            }
            else
            {
                lblUploadStatus.Text = "Please upload proper file.";
            }
        }
        catch (Exception ex)
        {
            lblUploadStatus.Text = "Error in uploading file." + ex.Message;
        }
    }
