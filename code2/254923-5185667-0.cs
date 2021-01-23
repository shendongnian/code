    [Test]
		public void getLanguageNames()
		{
			var names = GetResourceLanguageNames(Assembly.GetExecutingAssembly(), "GUILanguage", "LanguageName");
			Console.WriteLine(string.Join("-",names));
		}
		public IEnumerable<string> GetResourceLanguageNames(Assembly assembly, string resourceName, string key)
		{
			var regex = new Regex(string.Format(@"(\w)?{0}(\.\w+)?", resourceName));
			
			var matchingResources =  assembly.GetManifestResourceNames()
										.Where(n => regex.IsMatch(n)).Select(rn=>rn.Remove(rn.LastIndexOf(".")));
			return matchingResources.Select(rn => new ResourceManager(rn, assembly).GetString(key));
		}
