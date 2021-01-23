    public static string MakeFileNameWebSafe(string path, string replace, string other)
	{
		var folder = System.IO.Path.GetDirectoryName(path);
		var name = System.IO.Path.GetFileNameWithoutExtension(path);
		var ext = System.IO.Path.GetExtension(path);
		if (name == null) return path;
		var allowed = @"a-zA-Z0-9" + replace + (other ?? string.Empty);
		name = System.Text.RegularExpressions.Regex.Replace(name.Trim(), @"[^" + allowed + "]", replace);
		name = System.Text.RegularExpressions.Regex.Replace(name, @"[" + replace + "]+", replace);
		if (name.EndsWith(replace)) name = name.Substring(0, name.Length - 1);
		return folder + name + ext;
	}
