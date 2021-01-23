	private IEnumerable<FileInfo> FindFiles()
	{
		DirectoryInfo sourceDirectory = new DirectoryInfo(@"C:\temp\mydirectory");
		string foldersFilter = "*bin*,*obj*";
		string fileTypesFilter = "*.mp3,*.wma,*.mp4,*.wav";
		// filter by folder name and extension
		IEnumerable<DirectoryInfo> directories = foldersFilter.Split(',').SelectMany(pattern => sourceDirectory.EnumerateDirectories(pattern, SearchOption.AllDirectories));
		List<FileInfo> files = new List<FileInfo>();
		files.AddRange(directories.SelectMany(dir => fileTypesFilter.Split(',').SelectMany(pattern => dir.EnumerateFiles(pattern, SearchOption.AllDirectories))));
			
		// Pick up root files
		files.AddRange(fileTypesFilter.Split(',').SelectMany(pattern => sourceDirectory.EnumerateFiles(fileTypesFilter, SearchOption.TopDirectoryOnly)));
		// filter just by extension
		IEnumerable<FileInfo> files2 = fileTypesFilter.Split(',').SelectMany(pattern => sourceDirectory.EnumerateFiles(pattern, SearchOption.AllDirectories));
	}
