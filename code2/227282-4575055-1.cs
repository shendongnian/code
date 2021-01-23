	Dictionary<string, DateTime> Dates = new Dictionary<string, DateTime>();
	for (int i = 0; i <= Files.Length - 1; i++)
	{
		request = (FtpWebRequest)WebRequest.Create(new Uri(FtpPath + Files[i]));
		request.Credentials = new NetworkCredential("user", "password");
		request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
		response = (FtpWebResponse)request.GetResponse();
		DateTime FileDate = response.LastModified;
		Dates.Add(Files[i], FileDate);
	}
