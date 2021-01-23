	try
	{
			// Remove what other controls may have been put on the page
		context.ClearContent();
			// Clear any headers
		context.ClearHeaders();
	}
	catch (System.Web.HttpException theException)
	{
			// Ignore this exception, which could occur if there were no HTTP headers in the response
	}
	context.ContentType = "application/octet-stream";
	context.AddHeader("Content-Disposition", "attachment; filename=" + sFileNameForUser);
	context.TransmitFile(sFileName);
		// Ensure the file is properly flushed to the user
	context.Flush();
		// Ensure the response is closed
	context.Close();
	try
	{
		context.End();
	}
	catch
	{
	}
