	public static bool IsValidFileName(string name) {
		if(string.IsNullOrWhiteSpace(name)) return false;
		if(name.Length > 1 && name[1] == ':') {
			if(name.Length < 4 || name.ToLower()[0] < 'a' || name.ToLower()[0] > 'z' || name[2] != '\\') return false;
			name = name.Substring(3);
		}
		if(name.StartsWith("\\\\")) name = name.Substring(1);
		if(name.EndsWith("\\") || !name.Trim().Equals(name) || name.Contains("\\\\") ||
            name.IndexOfAny(Path.GetInvalidFileNameChars().Where(x=>x!='\\').ToArray()) >= 0) return false;
		return true;
	}
