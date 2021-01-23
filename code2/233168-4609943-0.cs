	public void ProcessRequest(HttpContext context)
	{
		// example for the csv
		context.Response.ContentType = "text/html";
		// what is the file name that the user see to save
		context.Response.AppendHeader("Content-disposition", "attachment; filename=" + cFileNameToShowAndDownload);
		context.Response.Write("here is your text to send");
		context.Response.Flush();
	}
