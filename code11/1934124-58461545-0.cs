    if (File.Exists(your_file_path)){
        string yourfile = File.ReadAllText(your_file_path);
        // Now the file is a simple string that you can manipulate using
        // string split functions.
        // For Example:
        // break by lines
        string[] lines = yourfile.Split('\n');
        foreach (string line in lines){
            if (line.Substring(0,4) == "Name"){
                // replace the necessary line
                line = "Name = Tim";
                break;
            }
        }
        
        // Join the array again
        yourfile = lines.Join("\n", lines);
        File.WriteAllText(your_file_path, yourfile);
    }
