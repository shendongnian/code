    StringBuilder fileContents = new StringBuilder();
    // Read the file and display it line by line.
    System.IO.StreamReader file =
    new System.IO.StreamReader(@"c:\test.txt");
    while((line = file.ReadLine()) != null)
    {
    fileContents.Append( WebUtility.UrlEncod(line)+ '%0A');
    }
    
    file.Close();
