    /* Delete Directory*/
                private void deleteDirectory(string directoryName)
                {
                    try
                    {
                        //Check files inside 
                        var direcotryChildren  = directoryListSimple(directoryName);
                        if (direcotryChildren.Any() && (!string.IsNullOrWhiteSpace(direcotryChildren[0])))
                        {
                            foreach (var child in direcotryChildren)
                            {
                                delete(directoryName + "/" +  child);
                            }
                        }
    
    
                        /* Create an FTP Request */
                        ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + directoryName);
                        /* Log in to the FTP Server with the User Name and Password Provided */
                        ftpRequest.Credentials = new NetworkCredential(user, pass);
                        /* When in doubt, use these options */
                        ftpRequest.UseBinary = true;
                        ftpRequest.UsePassive = true;
                        ftpRequest.KeepAlive = true;
                        /* Specify the Type of FTP Request */
                        ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
                        
                        /* Establish Return Communication with the FTP Server */
                        ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                        /* Resource Cleanup */
                        ftpResponse.Close();
                        ftpRequest = null;
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                    return;
                }
