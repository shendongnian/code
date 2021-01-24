    public string GetHash(String fileLoc)
    {
        using (FileStream stream = File.OpenRead(fileLoc))
        {
            HashAlgorithm sha = new SHA256CryptoServiceProvider();
            byte[] checksum = sha.ComputeHash(stream);
            return BitConverter.ToString(checksum).Replace("-", String.Empty);
        }
    }
    private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        var hash = await Task.Run(() => help.getHash(*some file directory*));
    }
