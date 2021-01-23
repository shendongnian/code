    void ProcessFolder(string path) {
        // Process the files 
        foreach(var file in Directory.GetFiles(path)) {  
            // Process each file  
        }  
        // process the sub folders
       foreach (var subFolder in Directory.GetDirectories(path).Where(fld => System.IO.Path.GetFilename(fld) != "ORJ")) {
            ProcessFolder(subFolder);
        }
    }
