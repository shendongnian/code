    bool DoneOK = false;
    FtpWebRequest request = null;
    FtpWebResponse response = null;
    try {
        // Get the object used to communicate with the server.
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + FtpInfo.FtpServer.Trim() + "/" + FtpInfo.FtpFolderPath.Trim() + "/" + FileName.Trim()));
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.Proxy = null;
    
        // FTP site uses anonymous logon.
        request.Credentials = new NetworkCredential(FtpInfo.UserNameForFTP.Trim(), FtpInfo.PasswordForFTP.Trim());
        request.UsePassive = FtpInfo.UsePassive;
        request.KeepAlive = FtpInfo.KeepAlive;
        request.Timeout = FtpInfo.TimeOut; //Milliseconds
        request.UseBinary = true;
        request.ReadWriteTimeout = FtpInfo.TimeOut; //Milliseconds
        
        long length = new FileInfo(SourceLocation).Length;
        long uploadSize = 0;
        if ( chunks < 1 )
             chunks = 1024;
             
        buffLength = chunks;
        byte[] buff = new byte[buffLength];
        int contentLen = 0;
        string MSG = "";
        
        using (FileStream fs = File.OpenRead (SourceLocation))
        using (Stream strm = request.GetRequestStream())
        {
            while ((contentLen = fs.Read(buff, 0, buffLength)) > 0 )
            {
            MSG = "Uploading '" + FileName + "'......" + "Bytes Uploaded (" + uploadSize.ToString() + "/" + length.ToString() + ")";
            string tmp_MSG = MSG;
            Dispatcher.Invoke(DispatcherPriority.Normal, () => { lblProgress.Content = tmpMSG; });
            strm.Write(buff, 0, contentLen);
            uploadSize += contentLen;
            };
            
            strm.Close();
            
            // necessary - the upload occurs really here !
            response = (FtpWebResponse) request.GetResponse();
            // check the response codes... for example FileActionOK...
            if ( response.StatusCode == System.Net.FtpStatusCode.FileActionOK )
                 DoneOK = true;
            
            response.Close(); response = null;
            request = null;
        }
        }
    catch
    {
    };
    
    if ( request != null )    
         {
         if ( response != null )
              {
              try { response.Close(); } catch {};
              response = null;
              }
              
         if ( !DoneOK )
              {
              try { request.Abort (); } catch {};
              }
              
         request = null;
         }
