      protected void FileUploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                //File upload logic. Returns path of uploaded file
                string filePath = Server.MapPath("~/Files/") + Path.GetFileName(FileUploader.PostedFile.FileName);
                  
                //File save to server. Saves file name as uploaded by user to folder, "Files" on the server
                string path = System.IO.Path.Combine("~/Files/",Path.GetFileName(FileUploader.PostedFile.FileName));
                string day = DateTime.Now.ToString("ss_mm_hh_dd_MM_yyyy");
                
                FileUploader.SaveAs(Server.MapPath(path));
                //Function to insert values in excel sheet to database
                InsertIntoDatabase(filePath)
                 //Resave file to keep track of uploaded files
                File.Copy(filePath, day + filePath);
                File.Delete(filePath);
            }
            catch (Exception Ex)
            {
            }//End try
        }//End FileUpload 
