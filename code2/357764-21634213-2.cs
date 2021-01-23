    var tasks = from url in urls.Distinct()
                select new WebClient().DownloadDataTaskAsync(new Uri(url));
	try
	{
	    await TaskEx.WhenAll(tasks);
	}
	catch(Exception)
	{
	}
	
	var files = tasks
		.Where(f => !f.IsFaulted)
		.Select(f => f.Result);
		
    return files.Sum(file => file.Length);
