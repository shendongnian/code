    if (FileUploadControl.HasFile)
            {
                try
                {
                    string theUserId = Session["UserID"].ToString();
                    OdbcConnection cn = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver}; Server=localhost; Database=gymwebsite2; User=x; Password=x;");
                    cn.Open();
    //
    //Something like this 
    //
                    OdbcCommand sc = new OdbcCommand(string.format("SELECT picturepath FROM Pictures WHERE UserID ='{0}'", theUserId), cn);
                    OdbcDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                          if (System.IO.File.Exists(reader[0]))
                          {
                               System.IO.File.Delete(reader[0]);
                          }
                    }
                    string filenameDB = Path.GetFileName(FileUploadControl.FileName);
                    string fileuploadpath = Server.MapPath("~/userdata/"+theUserId+"/uploadedimage/")+Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(fileuploadpath);
                    string fileuploadpaths = ("~/userdata/"+theUserId+"/uploadedimage/")+filenameDB;
                    StatusLabel.Text = "Upload status: File uploaded!";
    
                    OdbcCommand cmd = new OdbcCommand("INSERT INTO Pictures (UserID, picturepath) VALUES ('"+theUserId+"','"+fileuploadpaths+"')", cn);
                    cmd.ExecuteNonQuery();
                }
    
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
    
                }
    
            }
        }
    
    }
