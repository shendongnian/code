    using (SftpClient sftp = new SftpClient("ftp.website.com", 22,"username", "password")
    {
       sftp.Connect();
       
       if (sftp.IsConnected)
       {
         using (Filestream fs = new FileStream("Output.txt", FileMode.Create))
          {
            sftp.DownloadFile("/file/Client/Input.txt", fs);
          }
       } 
       
       sftp.Disconnect();
     }
