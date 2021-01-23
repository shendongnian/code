                    FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://127.0.0.1/1542");
                    ftpRequest.Credentials = new NetworkCredential("6584", "123456");
                    ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                    ftpRequest.UsePassive = false;
                    FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                    StreamReader streamReader = new StreamReader(response.GetResponseStream());
    
                    List<string> directories = new List<string>();
    
                    string line = streamReader.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        directories.Add(line);
                        line = streamReader.ReadLine();
                    }
    
                    streamReader.Close();
                    return true;
