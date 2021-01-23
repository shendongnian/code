	public static class VersionExtensions
	{
		public static int CompareTo(this Version version, Version otherVersion, int significantParts)
		{
			if(version == null)
			{
				throw new ArgumentNullException("version");
			}
			if(otherVersion == null)
			{
				return 1;
			}
			if(version.Major != otherVersion.Major && significantParts >= 1)
				if(version.Major > otherVersion.Major)
					return 1;
				else
					return -1;
			if(version.Minor != otherVersion.Minor && significantParts >= 2)
				if(version.Minor > otherVersion.Minor)
					return 1;
				else
					return -1;
			if(version.Build != otherVersion.Build && significantParts >= 3)
				if(version.Build > otherVersion.Build)
					return 1;
				else
					return -1;
			if(version.Revision != otherVersion.Revision && significantParts >= 4)
				if(version.Revision > otherVersion.Revision)
					return 1;
				else
					return -1;
			return 0; 
		}
	}
