    public static IConverter GetConverter()
	{
		lock (Locker)
		{
		if (converter != null)
			{
				return converter;
			}
			var tempFolderDeployment = new TempFolderDeployment();
			var winAnyCpuEmbeddedDeployment = new WinAnyCPUEmbeddedDeployment(tempFolderDeployment);
			IToolset toolSet;
			if (HostingEnvironment.IsHosted)
			{
				toolSet = new RemotingToolset<PdfToolset>(winAnyCpuEmbeddedDeployment);
			}
			else
			{
				toolSet = new PdfToolset(winAnyCpuEmbeddedDeployment);
			}
			converter = new ThreadSafeConverter(toolSet);
		}
		return converter;
	}
