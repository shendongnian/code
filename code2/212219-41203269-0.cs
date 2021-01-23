		public static string GetPath(this Assembly assembly)
		{
			return Path.GetDirectoryName(assembly.GetFileName());
		}
		public static string GetFileName(this Assembly assembly)
		{
			return assembly.CodeBase.GetPathFromUri();
		}
		public static string GetPathFromUri(this string uriString)
		{
			var uri = new Uri(Uri.EscapeUriString(uriString));
			return String.Format("{0}{1}", Uri.UnescapeDataString(uri.PathAndQuery), Uri.UnescapeDataString(uri.Fragment));
		}
