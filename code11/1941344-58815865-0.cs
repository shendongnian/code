		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			var pathInfo = HttpContext.Current.Request.PathInfo.ToLowerInvariant();
			if (pathInfo.StartsWith("/abc/"))
			{
				foreach (var s in new[] { "/abc/path1", "/abc/path2" })
				{
					if (pathInfo == s)
					{
						var rawUrl = HttpContext.Current.Request.RawUrl.ToLower(CultureInfo.InvariantCulture);
						HttpContext.Current.RewritePath($"{rawUrl}/");
						break;
					}
				}
			}
		}
