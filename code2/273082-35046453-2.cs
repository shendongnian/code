	public static bool IsFullPath(string path) {
		return !String.IsNullOrWhiteSpace(path)
			&& path.IndexOfAny(System.IO.Path.GetInvalidPathChars().ToArray()) == -1
			&& Path.IsPathRooted(path)
			&& !Path.GetPathRoot(path).Equals(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal);
	}
