        protected void Application_BeginRequest()
		{
            if (Request.IsLocal || User.IsInRole("Developer"))
			{
				MiniProfiler.Start();
			    MiniProfiler.Settings.IgnoredPaths = new[] { "static", "webresource.axd", "styles", "images" };
			}
		 }
