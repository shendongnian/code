    //create dictionaty where id is packageId, and columns that should be deleted for that packageId
	Dictionary<int, int[]> columnsDictionary = new Dictionary<int, int[]>();
    //add values for each key
	columnsDictionary.Add(358, new int[] { 15, 16, 17, 18, 19, 20 });
	columnsDictionary.Add(469, new int[] { 16, 17, 18, 19, 20 });
	//etc...
	//check if this packageId is in present as key in dictionary
    if (!columnsDictionary.ContainsKey(packageId))
        return; //if not, exit or show some error...
    //delete corresponding columns in one loop
	foreach (int i in columnsDictionary[packageId])
	{
		wsSheet.DeleteColumn(i);
	}
