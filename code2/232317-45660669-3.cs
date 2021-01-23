    private void button1_Click(object sender, EventArgs e)
    {
        // Run Download on background thread
        Task.Run(() => Download());
    }
    private void Download()
    {
        try
        {
            const string url = "ftp://ftp.example.com/remote/path/file.zip";
            NetworkCredential credentials = new NetworkCredential("username", "password");
            // Query size of the file to be downloaded
            WebRequest sizeRequest = WebRequest.Create(url);
            sizeRequest.Credentials = credentials;
            sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            int size = (int)sizeRequest.GetResponse().ContentLength;
            progressBar1.Invoke(
                (MethodInvoker)(() => progressBar1.Maximum = size));
            
            // Download the file
            WebRequest request = WebRequest.Create(url);
            request.Credentials = credentials;
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            using (Stream ftpStream = request.GetResponse().GetResponseStream())
            using (Stream fileStream = File.Create(@"C:\local\path\file.zip"))
            {
                byte[] buffer = new byte[10240];
                int read;
                while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, read);
                    int position = (int)fileStream.Position;
                    progressBar1.Invoke(
                        (MethodInvoker)(() => progressBar1.Value = position));
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
