    string string greatestVersionNumber = ""
    using (StreamReader sr = new StreamReader(path)) 
    {
        while (sr.Peek() >= 0) 
        {
            var line = sr.ReadLine());
            var versionNumber = line.Replace(
                @"sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_", "");
            if(versionNumber.Length != line.Length)
                greatestVersionNumber = versionNumber;
        }
    }
    
