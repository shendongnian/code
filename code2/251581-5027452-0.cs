    public List<string> GetAllProfiles()
		{
			List<string> profileNames = new List<string>();
			using (StreamReader reader = new StreamReader(_folderLocation + "profiles.pg"))
			{
				string profiles = reader.ReadToEnd();
				var regex = new Regex("\nname=([^\r]{0,})", RegexOptions.IgnoreCase);
				var regexMatchs = regex.Matches(profiles);
				profileNames.AddRange(from Match regexMatch in regexMatchs select regexMatch.Groups[1].Value);
			}
			return profileNames;
		}
