    public async Task FtpAsync(string sourceFile, Uri destinationUri, string user, SecureString password, IProgress<decimal> progress, CancellationToken token)
    {
      const int bufferSize = 128 * 1024;  // 128kb buffer
      progress.Report(0m);
    
      var request = (FtpWebRequest)WebRequest.Create(destinationUri);
      request.Method = WebRequestMethods.Ftp.UploadFile;
      request.Credentials = new NetworkCredential(user, password);
    
      token.ThrowIfCancellationRequested();
    
      using (var fileStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, true))
      {
        using (var ftpStream = await request.GetRequestStreamAsync())
        {
          var buffer = new byte[bufferSize];
          int read;
    
          while ((read = await fileStream.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
          {
            await ftpStream.WriteAsync(buffer, 0, read, token);
            var percent = 100m * ((decimal)fileStream.Position / fileStream.Length);
            progress.Report(percent);
          }
        }
      }
    
      var response = (FtpWebResponse)await request.GetResponseAsync();
      var success = (int)response.StatusCode >= 200 && (int)response.StatusCode < 300;
      response.Close();
      if (!success)
        throw new Exception(response.StatusDescription);
    }
