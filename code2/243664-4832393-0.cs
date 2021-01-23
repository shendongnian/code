    public static string[] MultipleFileFilter(ref string dir)
    {
        //determine our valid file extensions
        string validExtensions = "*.jpg,*.jpeg,*.gif,*.png";
    
        //create a string array of our filters by plitting the
        //string of valid filters on the delimiter
        string[] extFilter = validExtensions.Split(new char[] { ',' });
    
        //ArrayList to hold the files with the certain extensions
        ArrayList files = new ArrayList();
    
        //DirectoryInfo instance to be used to get the files
        DirectoryInfo dirInfo = new DirectoryInfo(dir);
    
        //loop through each extension in the filter
        foreach (string extension in extFilter)
        {
            //add all the files that match our valid extensions
            //by using AddRange of the ArrayList
            files.AddRange(dirInfo.GetFiles(extension));
        }
    
        //convert the ArrayList to a string array
        //of file names
        return (string[])files.ToArray(typeof(string));
    }
