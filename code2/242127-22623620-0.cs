    public void delete(string deleteFile)
                {
                    try
                    {
                        /* Create an FTP Request */
                        ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + deleteFile);
                        /* Log in to the FTP Server with the User Name and Password Provided */
                        ftpRequest.Credentials = new NetworkCredential(user, pass);
                        /* When in doubt, use these options */
                        ftpRequest.UseBinary = true;
                        ftpRequest.UsePassive = true;
                        ftpRequest.KeepAlive = true;
                        /* Specify the Type of FTP Request */
                        ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                        /* Establish Return Communication with the FTP Server */
                        ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                        /* Resource Cleanup */
                        ftpResponse.Close();
                        ftpRequest = null;
                    }
                    catch (Exception ex) { 
                        //Console.WriteLine(ex.ToString()); 
                        try
                        {
                            deleteDirectory(deleteFile);
                        }
                        catch { }
    
                    
                    }
                    return;
                }
