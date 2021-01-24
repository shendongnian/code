    try
            {
                UploadVideo obj = new UploadVideo();
                string filename = fuUploadVideo.FileName;
                string path = Server.MapPath("Uploads4");
                string strFinalFileName = Path.GetFileName(fuUploadVideo.FileName);
                long FileLength = fuUploadVideo.PostedFile.ContentLength;
                long uploadchunklimit;
                int SizeLimit = (int)FileLength;
                if (FileLength <= 1024)
                {
                    uploadchunklimit = 1;
                    SizeLimit = (int)FileLength;
                }
                else if (FileLength > 1024)
                {
                    uploadchunklimit = FileLength / 1024;
                    SizeLimit = 10;
                }
                else if (FileLength <= 10240 && FileLength > 1024)
                {
                    uploadchunklimit = FileLength / 1024;
                }
                else
                {
                    uploadchunklimit = FileLength / 1024;
                }
    
                long lngSize = (long)SizeLimit;
                lngSize = 1024 * 1024;
                string ext = Path.GetExtension(fuUploadVideo.PostedFile.FileName);
                
                fuUploadVideo.PostedFile.SaveAs(Server.MapPath("Uploads4\\" + filename));
                path = "Uploads4\\" + filename;
                SqlConnection con = new SqlConnection(str);
               
                cmd = new SqlCommand("Insert into electronicmedia(Video_Name,url) values(@Video,'" + path + "')", con);
                cmd.Parameters.AddWithValue("Video", TextBox2.Text);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblinfo.Text = " uploaded successfully ";
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
