    static string GetNextFolderName(string folderName)
    {
        int lastDotPosition = folderName.LastIndexOf('.');
        string lastPartOfFolderName = folderName.Substring(lastDotPosition + 1);
        
        int number;
        if (int.TryParse(lastPartOfFolderName, out number))
        {
            number++;
            return folderName.Substring(0, lastDotPosition + 1) + number.ToString();
        }
        else
        {
            // You've got a problem on your hands, here.
            throw new FormatException();
        }
    }
