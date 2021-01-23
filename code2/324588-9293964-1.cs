    List<string> urlsList = new List<string>();
    urlsList.Add("http://www.gin.de");
    // ^^ n times ...
    // create shaped array with content 
    object[,] content = new object [urlsList.Count, 1];
    foreach(string url in urlsList)
    {
        content[i, 1] = string.Format("=HYPERLINK(\"{0}\")", url);
    }
    // get Range
    string rangeDescription = string.Format("A1:A{0}", urlsList.Count+1) // excel indexes start by 1
    Xl.Range xlRange = worksheet.Range[rangeDescription, XlTools.missing];
    
    // set value finally
    xlRange.Value2 = content;
    
