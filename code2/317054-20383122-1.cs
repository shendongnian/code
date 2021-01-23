        protected void Application_BeginRequest()
		{
            if (Request.IsLocal)
			{
				MiniProfiler.Start();
			    MiniProfiler.Settings.IgnoredPaths = new[] { "static", "webresource.axd", "styles", "images" };
			}
		 }
