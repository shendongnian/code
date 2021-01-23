      FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(_URL);
      FtpWebResponse res;
      StreamReader reader;
      ftp.Credentials = new NetworkCredential(_User, _Pass);
      ftp.KeepAlive = false;
      ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
      ftp.UsePassive = _PassiveMode;
      try
      {
        using (res = (FtpWebResponse)ftp.GetResponse())
        {
          reader = new StreamReader(res.GetResponseStream());
        }
      }
      catch
      {
        //Handling code here.
      }
