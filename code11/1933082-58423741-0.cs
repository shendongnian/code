            string host = ""; // your server name
            int port =22 ;// your port
            string username ="";// your sftp server username
            string password="";// your sftp server  password
            SftpClient client = new SftpClient(host, port, username, password);
            client.Connect();
            string path = "";// The file to write to
            byte[] bytes = Encoding.UTF8.GetBytes("test");
            client.WriteAllBytes(path, bytes);
            client.Dispose();
            client.Disconnect();
  [1]: https://www.nuget.org/packages/Renci.SshNet.Async/
