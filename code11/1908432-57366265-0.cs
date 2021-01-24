    private void UpdateFile(string newValue, string path, string pattern)
    {
	   var regex = new Regex(pattern, RegexOptions.IgnoreCase);
	   int index = 0;
	   string line = "";
	   using (var fileStream = File.OpenRead(path))
	   using (var streamReader = new StreamReader(fileStream, Encoding.Default, true, 128))
	   {
		   while ((line = streamReader.ReadLine()) != null)
		   {
			   if (regex.Match(line).Success)
			   {
			   	break;
			   }
			   index += Encoding.ASCII.GetBytes(line + "\n").Length;
		   }
	   }
	   if (line != null)
	   {
		   using (Stream stream = File.Open(path, FileMode.Open))
		   {
			   stream.Position = index;
			   var newBytes = Encoding.Default.GetBytes(regex.Replace(line + "\n", newValue));
			   stream.Write(newBytes, 0, newBytes.Length);
		   }
	   }
    }
