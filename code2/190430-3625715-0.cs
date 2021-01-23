    public static string GetUniqueFilename(string folder, string postedFileName)
    {
        string fileExtension = postedFileName.Substring(postedFileName.LastIndexOf('.') + 1);
        int index = 2;
        while (File.Exists(string.Format("{0}/{1}", folder, postedFileName)))
        {
            if (index == 2)
                postedFileName =
                    string.Format("{0} ({1}).{2}",
                                  postedFileName.Substring(0, postedFileName.LastIndexOf('.')),
                                  index,
                                  fileExtension);
            else
                postedFileName =
                    string.Format("{0} ({1}).{2}",
                                  postedFileName.Substring(0, postedFileName.LastIndexOf(' ')),
                                  index,
                                  fileExtension);
            index++;
        }
        return postedFileName;
    }
