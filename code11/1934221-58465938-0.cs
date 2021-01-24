    var retryPolicy = Policy
      .Handle<Exception>()
      .WaitAndRetry(3, retryAttempt => 
        TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) 
      );
    
    using (var client = new SftpClient("ftp.site.com", 22, "userName", "password")) {
        retryPolicy.Execute(() => {
            /* file uploading .. */
        });
    }
