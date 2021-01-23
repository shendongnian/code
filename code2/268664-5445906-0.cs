    public void MoveFilesToSplitDestination(string source, string destination1, string destination2)
    {
        var fileList = Directory.GetFiles(source);
        int fileCount = fileList.Count();
        for(int i = 0; i < fileCount; i++)
        {
            string moveToDestinationPath = (i < fileCount/2) ? destination1 : destination2;
            fileList[i].MoveTo(moveToDestination);
        }
    }
