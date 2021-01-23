          protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
            {    
                if (AsyncFileUpload1.HasFile)
                {
                    string strPath = MapPath("~/Uploads/") + System.IO.Path.GetFileName(e.filename);
                     // gets extension of a file to check for a valid excel file
                    string ext = System.IO.Path.GetExtension(e.filename); 
                    if (ext.ToLower() == ".xlsx" || ext.ToLower() == ".xls")
                    {
                        AsyncFileUpload1.SaveAs(strPath);
                    }       
                    DataTable dt = getdata(strPath); // get data from excel file
                    BindGrid(dt); 
                }
                     
              
            }
