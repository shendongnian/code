        public string[] GetFileList(string URL)
                {
                    string[] downloadFiles;
                    StringBuilder result = new StringBuilder();
                    FtpWebRequest reqFTP;
                    string ftpUserID = "xyz";
                    string ftpPassword = "123";
                    try
                    {
        
                        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(URL));
                        reqFTP.UseBinary = true;    
                        reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                        reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                        reqFTP.Proxy = null;
                        WebResponse response = reqFTP.GetResponse();
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        //MessageBox.Show(reader.ReadToEnd());
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                           ProcessGotFile(line);
        
                            result.Append(line);
                            result.Append("\n");
                            line = reader.ReadLine();
                        }
                        result.Remove(result.ToString().LastIndexOf('\n'), 1);
                        reader.Close();
                        response.Close();
                        //MessageBox.Show(response.StatusDescription);
                        return result.ToString().Split('\n');
                    }
        
        public void ProcessGotFile(string line)
                {
                   string message_id;
                   FTPclient ftp = new FTPclient();
                   // download the file
                   Download(@"D:\", line, "ftp://xyz:123@ftp.theFTP.com");
    // Here you got `the` file locally and can start deal with it through the FileInfo class
                }
        
         public void Download(string filePath, string fileName, string URL)
                {
                    FtpWebRequest reqFTP;
                    try
                    {
        
                        string ftpUserID = "xyz";
                        string ftpPassword = "123";
                        //filePath = <<The full path where the file is to be created.>>, 
                        //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
                        FileStream outputStream = new FileStream(filePath
        + "\\" + fileName, FileMode.Create);
        
                        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(URL + fileName));
                        reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                        
                        reqFTP.UseBinary = true;
                        reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                        reqFTP.Timeout = 500000;
                        FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                        Stream ftpStream = response.GetResponseStream();
                        long cl = response.ContentLength;
                        int bufferSize = 2048;
                        int readCount;
                        byte[] buffer = new byte[bufferSize];
                        readCount = ftpStream.Read(buffer, 0, bufferSize);
                        while (readCount > 0)
                        {
                            outputStream.Write(buffer, 0, readCount);
                            readCount = ftpStream.Read(buffer, 0, bufferSize);
                        }
                        
        
                        ftpStream.Close();
                        outputStream.Close();
                        response.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
