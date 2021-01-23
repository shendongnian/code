    NetworkCredential User = new NetworkCredential("UserName", "password");
    FtpWebRequest Wr =FtpWebRequest)FtpWebRequest.Create("ftp://Somwhere.com/somedirectory/Somefile.file");
	Wr.UseBinary = true;
	Wr.Method = WebRequestMethods.Ftp.Rename;
	Wr.Credentials = User;
	Wr.RenameTo = "/someotherDirectory/Somefile.file";
	back = (FtpWebResponse)Wr.GetResponse();
	bool Success = back.StatusCode == FtpStatusCode.CommandOK || back.StatusCode == FtpStatusCode.FileActionOK;
