    protected void btnOk_Click(object sender, EventArgs e)
    {
        long maxsize = 512000;
        string str = Path.GetFileName(FileUpload1.FileName);
        int filesize = FileUpload1.PostedFile.ContentLength;
        string fileexe = Path.GetExtension(FileUpload1.FileName);
        if (filesize <= maxsize )
        {
            if (fileexe == ".jpg" || fileexe == ".jpeg")
            {
                FileUpload1.SaveAs(Server.MapPath("~/Image/" + str));
            }
            else
            {
                lblMsg.Text = "Image extension must be jpg or jpeg";
            }
        }
        else
        {
            lblMsg.Text = "File size is too large.";
        }
        
    }
