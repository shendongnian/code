		public static class YourClass
		{
			...
			public static MemberName SplitTdsName(string tdsName)
			{
				MemberName preSplitName = NameSplitter.Split(tdsName);
				return preSplitName;
			}
		}
		public static class NameSplitter
		{
			...
			public static MemberName Split(string fullName)
			{
				nameInFull = fullName;
				SetAllowedTitles();
				SplitNamesAndRemovePeriods();
				SetTitles();
				MemberName splitName = new MemberName(titles, firstNames, lastNames);
				return splitName;
			}
		}
		public struct MemberName
		{
			public string Title;
			public string FirstNames;
			public string LastNames;
			public MemberName(string title, string firstNames, string lastNames)
			{
				Title = title;
				FirstNames = firstNames;
				LastNames = lastNames;
			}
		}
