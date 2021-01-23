    public void Download(string filename)
        {
            // I try to download five times before crash
            for (int i = 1; i < 5; i++)
            {
                try
                {
                    FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(Global.Path + "/" + filename);
                    ftp.Credentials = new NetworkCredential(User, Pass);
                    ftp.KeepAlive = false;
                    ftp.Method = WebRequestMethods.Ftp.DownloadFile;
                    ftp.UseBinary = true;
                    ftp.Proxy = null;
                    int buffLength = 2048;
                    byte[] buff = new byte[buffLength];
                    int contentLen;
                    string LocalDirectory = Application.StartupPath.ToString() + "/downloads/" + filename;
                    using (FileStream fs = new FileStream(LocalDirectory, FileMode.Create, FileAccess.Write, FileShare.None))
                    using (Stream strm = ftp.GetResponse().GetResponseStream())
                    {
                        contentLen = strm.Read(buff, 0, buffLength);
                        while (contentLen != 0)
                        {
                            fs.Write(buff, 0, contentLen);
                            contentLen = strm.Read(buff, 0, buffLength);
                        }
                    }
                    Process.Start(LocalDirectory);
                    break;
                }
                catch (Exception exc)
                {
                    if (i == 5)
                    {
                        MessageBox.Show("Can't download, try number: " + i + "/5 \n\n Error: " + exc.Message,
                            "Problem downloading the file");
                    }
                }
            }
        }
