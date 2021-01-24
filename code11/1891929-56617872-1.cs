	// Setup session options
	var sessionOptions = new SessionOptions
	{
		Protocol = Protocol.Webdav,
		HostName = server,
		WebdavRoot = "/remote.php/webdav/" 
		UserName = user,
		Password = pass,
	};
	using (var session = new Session())
	{
		// Connect
		session.Open(sessionOptions);
		var files = Directory.GetFiles(sourceFolder);
		logger.DebugFormat("Got {0} files for uploading to nextcloud from folder <{1}>", files.Length, sourceFolder);
		TransferOptions tOptions = new TransferOptions();
		tOptions.TransferMode = TransferMode.Binary;
		tOptions.FilePermissions = new FilePermissions() { OtherRead = true, GroupRead = true, UserRead = true };
		
		string fileName = string.Empty;
		TransferOperationResult result = null;
		
		foreach (var localFile in files)
		{
			try
			{
				fileName = Path.GetFileName(localFile);
				result = session.PutFiles(localFile, string.Format("{0}/{1}", remotePath, fileName), false, tOptions);
				if (result.IsSuccess)
				{
					result.Check();
					logger.DebugFormat("Uploaded file <{0}> to {1}", Path.GetFileName(localFile), result.Transfers[0].Destination);
				}
				else
				{
					logger.DebugFormat("Error uploadin file <{0}>: {1}", fileName, result.Failures?.FirstOrDefault().Message);
				}
			}
			catch (Exception ex)
			{
				logger.DebugFormat("Error uploading file <{0}>: {1}", Path.GetFileName(localFile), ex.Message);
			}
		}
	}
