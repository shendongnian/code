    string path = @"E:\Current Project\Regex Samples\trunk\TestApplication\Uploads\Dynamicfolder123\EncryptedFile\";
    
    string pattern =@"
    (?:Uploads\\)       # Match but don't capture Uploads\
    (?<Dynamic>[^\\]+)  # Extract directory into named capture Dynamic
    ";
    // IgnoreWhitespace allows us to comment the pattern, does not affect regex processing.
    Console.WriteLine ( Regex.Match(path, 
                                    pattern, 
                                    RegexOptions.IgnorePatternWhitespace)
                             .Groups["Dynamic"].Value);
    
    /* Output
    Dynamicfolder123
    */
