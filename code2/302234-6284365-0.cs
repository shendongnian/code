    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem != null)
            {
                Label1.Text = "You selected " + DropDownList1.SelectedItem.Text;
                Session["uploadFolder"] = DropDownList1.SelectedItem.Text;
            }
        }
    
        protected void ASPxUploadControl1_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
        {
            if (e.IsValid)
            {
                string uploadDirectory = Server.MapPath("~/files/");
                //string uploadDirectory = @"\\DOCSD9F1\TECHDOCS\";
    
                string fileName = e.UploadedFile.FileName;
                string uploadfolder = Session["uploadFolder"] as String;
                string path = (uploadDirectory + uploadfolder + "/" + fileName);
                //string path = Path.Combine(Path.Combine(uploadDirectory, uploadFolder), fileName);
    
                e.UploadedFile.SaveAs(path);
                e.CallbackData = fileName;
            }
        }
