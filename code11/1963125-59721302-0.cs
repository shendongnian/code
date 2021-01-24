    using System.Net;
    using System.IO;
        
    String RemoteFtpPath = "ftp://ftp.csidata.com:21/Futures.20150305.gz";
    String LocalDestinationPath = "Futures.20150305.gz";
    String Username="yourusername";
    String Password = "yourpassword";
    Boolean UseBinary = true; // use true for .zip file or false for a text file
    Boolean UsePassive = false;
     
    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(RemoteFtpPath);
    request.Method = WebRequestMethods.Ftp.DownloadFile;
    request.KeepAlive = true;
    request.UsePassive = UsePassive;
    request.UseBinary = UseBinary;
     
    request.Credentials = new NetworkCredential(Username, Password);
     
    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
     
    Stream responseStream = response.GetResponseStream();
    StreamReader reader = new StreamReader(responseStream);
     
    using (FileStream writer = new FileStream(LocalDestinationPath, FileMode.Create))
    {
     
        long length = response.ContentLength;
        int bufferSize = 2048;
        int readCount;
        byte[] buffer = new byte[2048];
     
        readCount = responseStream.Read(buffer, 0, bufferSize);
        while (readCount > 0)
        {
            writer.Write(buffer, 0, readCount);
            readCount = responseStream.Read(buffer, 0, bufferSize);
        }
    }
     
    reader.Close();
    response.Close();
