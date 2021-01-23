	public ActionResult Upload()
	{
		// I like to keep all application data in App_Data, feel free to change this
		var dir = Server.MapPath("~/App_Data");
		if (!Directory.Exists(dir))
			Directory.CreateDirectory(dir);
		// extract file name from request and make sure it doesn't contain anything harmful
		var name = Path.GetFileName(Request.Headers["X-File-Name"]);
		foreach (var c in Path.GetInvalidFileNameChars())
			name.Replace(c, '-');
		// construct file path
		var path = Path.Combine(dir, name);
		// this variable will hold how much data we have received
		var written = 0;
		try
		{
			using (var output = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				var buffer = new byte[0x1000];
				var read = 0;
					
				// while there is something to read, write it to output and increase counter
				while ((read = Request.InputStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					output.Write(buffer, 0, read);
					output.Flush();
					written += read;
				}
			}
		}
		finally
		{
			// once finished (or when exception was thrown) check whether we have all data from the request
			// and if not - delete the file
			if (Request.ContentLength != written)
				System.IO.File.Delete(path);
		}
		return Json(new { success = true });
	}
