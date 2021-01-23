    try
    {
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAddr + "Default.aspx");
        request.Credentials = new NetworkCredential(userName, password);
        request.UseBinary = true; // Use binary to ensure correct dlv!
        request.Method = WebRequestMethods.Ftp.DownloadFile;
        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        Stream responseStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(responseStream);
        StreamWriter writer = new StreamWriter("Default.aspx");
        writer.Write(reader.ReadToEnd());
        reader.Close();
        writer.Close();
        response.Close();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }
