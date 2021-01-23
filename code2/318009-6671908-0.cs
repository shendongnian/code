    // Get the folders and sort them
    SortedList<string, Folder> sortList = new SortedList<string, Folder>();
    foreach (Folder nextFolder in this.Application.ActiveExplorer().Session.Folders)
        sortList.Add(nextFolder.Name, nextFolder);
    List<Folder> finalList = new List<Folder>();
    finalList.AddRange(sortList.Values);
    // Set the sorted list as the source
    Folders = finalList;
