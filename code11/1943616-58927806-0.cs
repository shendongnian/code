    static string SeekExtensionBehaviour(string path, string shellComand)
    {            
        string extension = System.IO.Path.GetExtension(path);
    
        string command = "not found";
    
        if (string.IsNullOrWhiteSpace(extension)) return command;
    
        using (RegistryKey keyExt = Registry.ClassesRoot.OpenSubKey(extension))
        {
            if (keyExt == null) return command;
    
            var keyRealExt = keyExt.GetValue("");
            
            if (string.IsNullOrEmpty(keyRealExt.ToString())) return command;
    
            using (RegistryKey keyReal = Registry.ClassesRoot.OpenSubKey(keyRealExt.ToString()))
            {
                if (keyReal == null) return command;
    
                string keycommandPath = string.Format(@"shell\{0}\command", shellComand); // New, Open or Edit
                
                using (RegistryKey keyCommand = keyReal.OpenSubKey(keycommandPath))
                {
                    command = keyCommand.GetValue("").ToString();
                }
            }
        }
        
        return command; // "C:\Program Files (x86)\Microsoft Office\Root\Office16\WINWORD.EXE" /n "%1" /o "%u"
    }
    
    string command = SeekExtensionBehaviour("override shell command.dot", "Open");
