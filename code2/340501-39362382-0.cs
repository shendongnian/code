    private void UploadFileToFTP()
    {
       FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create("ftp://www.server.com/sample.txt");
    
       ftpReq.UseBinary = true;
       ftpReq.Method = WebRequestMethods.Ftp.UploadFile;
       ftpReq.Credentials = new NetworkCredential("user", "pass");
    
       byte[] b = File.ReadAllBytes(@"E:\sample.txt");
       ftpReq.ContentLength = b.Length;
       using (Stream s = ftpReq.GetRequestStream())
       {
            s.Write(b, 0, b.Length);
       }
    
       FtpWebResponse ftpResp = (FtpWebResponse)ftpReq.GetResponse();
    
       if (ftpResp != null)
       {
             if(ftpResp.StatusDescription.StartsWith("226"))
             {
                  Console.WriteLine("File Uploaded.");
             }
       }
    }
