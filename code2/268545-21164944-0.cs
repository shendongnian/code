    using (WebClientEx client = new WebClientEx())
    {
      client.IntTimeout = intTimeout;
      client.DownloadString(strReportUrlPrefix + strReportUrlQuery);
    
      NameValueCollection auth = new NameValueCollection
      {
        { "j_username", strReportUsername},
        { "j_password", strReportPassword}
      };
    
      byte[] data = client.UploadValues(strReportUrlPrefix + "j_security_check", auth);
    
      // LOGIC HERE WITH DATA
    }
