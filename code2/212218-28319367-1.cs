		public static string GetAssemblyFullPath(Assembly assembly)
		{
		    string codeBasePseudoUrl = assembly.CodeBase; // "pseudo" because it is not properly escaped
			if (codeBasePseudoUrl != null) {
				const string filePrefix3 = @"file:///";
				if (codeBasePseudoUrl.StartsWith(filePrefix3)) {
					string sPath = codeBasePseudoUrl.Substring(filePrefix3.Length);
					string bsPath = sPath.Replace('/', '\\');
					Console.WriteLine("bsPath: " + bsPath);
					string fp = Path.GetFullPath(bsPath);
					Console.WriteLine("fp: " + fp);
					return fp;
				}
			}
			System.Diagnostics.Debug.Assert(false, "CodeBase evaluation failed! - Using Location as fallback.");
			return Path.GetFullPath(assembly.Location);
		}
