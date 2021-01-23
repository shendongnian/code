            if (FileUpload1.HasFile)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string extension = "." + FileName.Split('.')[1].ToString();
                string FileName_Guid = Convert.ToString(Guid.NewGuid()) + extension;
                FileUpload1.PostedFile.SaveAs(@"C:\Uploads\" + FileName_Guid);
                string Platform_Config_ID = PlatformConfigID.Value;
                DataTable dt = new DataTable();
                dt = DAL.Upload_File(FileName_Guid, FileName, Platform_Config_ID);
                                
                gv_Files.DataSource = dt;
                gv_Files.DataBind();
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(gv_Files);
            }
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            try
            {                
                LinkButton lnkDownload = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkDownload.NamingContainer;
                LinkButton download = row.FindControl("lnkDownload") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(download);
                string FileName = (sender as LinkButton).CommandArgument.Split(';')[0].ToString();
                string OriginalFileName = (sender as LinkButton).CommandArgument.Split(';')[1].ToString();
                string FilePath = @"C:\Uploads\" + FileName.ToString();
                FileInfo file = new FileInfo(FilePath);
                if (file.Exists)
                {                    
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + OriginalFileName);
                    Response.Headers.Set("Cache-Control", "private, max-age=0");
                    Response.WriteFile(FilePath);                    
                    Response.End();                                     
                }                
            }
            catch (Exception ex)
            {
                // do nothing
            }
        }
            
        protected void DeleteFile(object sender, EventArgs e)
        {
            string FileName_Guid = (sender as LinkButton).CommandArgument.Split(';')[0].ToString();
            string File_ID = (sender as LinkButton).CommandArgument.Split(';')[1].ToString();
            string Filename = (sender as LinkButton).CommandArgument.Split(';')[2].ToString();
            string Platform_Config_ID = (sender as LinkButton).CommandArgument.Split(';')[3].ToString();
            string FilePath = @"C:\Uploads\" + FileName_Guid;
            File.Delete(FilePath);
            DataTable dt = new DataTable();
            dt = DAL.Delete_File(File_ID, Filename, Platform_Config_ID);
            gv_Files.DataSource = dt;
            gv_Files.DataBind();
        }
