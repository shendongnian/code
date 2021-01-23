    public static string GetFolderRange(string folderName)
    {
       BaseConverter converter = new BaseConverter();
       NumericRangeFactory rangeFactory = new NumericRangeFactory(converter, 
          "aaaaaaa0", 9);
       string[] range = rangeFactory.GetStringRange(folderName);
       return range[0] + "-" + range[1];
    }
