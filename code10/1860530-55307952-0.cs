public IActionResult Files(string folder)
{
	List<MusicItems> MusicList = new List<MusicItems>();
	foreach (string folderName in folders)
	{
		// creates an item with an empty list of files
		var musicItem = new MusicItems { Name = folderName, MusicFiles = new List<MusicFile>() };
		
		foreach(var file in files)
		{
			// create the file
			musicFile = new MusicFile { Display = display, Url = MakeVirtualPath(fileName) };
			
			// add the file to the item, declared in the loop.
			musicItem.MusicFiles.Add(musicFile);
		}
		
		MusicList.Add(musicItem);
	}
	return View(MusicList);  
}
