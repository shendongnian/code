    Sftp sftp = new Sftp("localhost", "root", "bugmenot");
    try
    {
        sftp.Connect();
        ArrayList files = sftp.GetFileList("/tmp");
    }
    finally
    {
        sftp.Close();
    }
