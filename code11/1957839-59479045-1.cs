    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if(FileUploadControl.HasFile)
        {
            try
            {
                string filename = Path.GetFileName(FileUploadControl.FileName);
                FileUploadControl.SaveAs(Server.MapPath("~/") + filename);
                lblMessage.Text = "Upload status: File uploaded!";
            }
            catch(Exception ex)
            {
                lblMessage.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }
