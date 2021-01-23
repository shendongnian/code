	public override object OnPost(Files request)
	{
		var targetDir = GetPath(request);
		var isExistingFile = targetDir.Exists
			&& (targetDir.Attributes & FileAttributes.Directory) != FileAttributes.Directory;
		if (isExistingFile)
			throw new NotSupportedException(
			"POST only supports uploading new files. Use PUT to replace contents of an existing file");
		if (!Directory.Exists(targetDir.FullName))
		{
			Directory.CreateDirectory(targetDir.FullName);
		}
		foreach (var uploadedFile in base.RequestContext.Files)
		{
			var newFilePath = Path.Combine(targetDir.FullName, uploadedFile.FileName);
			uploadedFile.SaveTo(newFilePath);
		}
		return new FilesResponse();
	}
