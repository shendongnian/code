    string sPattern = "abc-\d+\.zip";
    string [] fileEntries = Directory.GetFiles(targetDirectory); 
    foreach(string fileName in fileEntries)
    {
      // here i need to compare , i mean i want to get only these files which are having these type of  filenames `abc-19870908.Zip`
      if(System.Text.RegularExpressions.Regex.IsMatch(filename , sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
      {
           // i want to do something
      }
    }
