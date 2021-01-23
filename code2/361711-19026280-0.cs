            try
            {
                    if (FileUpload1.HasFile)
                    {
                        ITransferFile clientUpload = new TransferFileClient();
                        RemoteFileInfo uploadRequestInfo = new RemoteFileInfo();
                        fileextension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                       
                        FileUpload1.PostedFile.SaveAs(Server.MapPath(Path.Combine("~/TempFolder/", FileName + fileextension)));
                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(Server.MapPath("~/TempFolder/") + FileName + fileextension);
                        using (System.IO.FileStream stream = new System.IO.FileStream(fileInfo.FullName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            uploadRequestInfo.FileName = FileUpload1.PostedFile.FileName;
                            uploadRequestInfo.Length = fileInfo.Length;
                            uploadRequestInfo.FileByteStream = stream;
                            clientUpload.UploadFile(uploadRequestInfo);
                        }
                    }
                
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("Error : " + ex.Message);
            }
            finally
            {
                if (File.Exists(Server.MapPath("~/TempFolder/") + FileName + fileextension))
                {
                    File.Delete(Server.MapPath("~/TempFolder/") + FileName + fileextension);
                }
            }
