    string[] lines = File.ReadAllLines(INILoc); //Considering INILoc is a string variable which contains file path.
    string newText = string.Empty;
    bool containsSearchResul = false;
    
    foreach (string line in lines)
        {
             if (line.Contains("[names]"))
               {
                    break;
               }
           newText += line;
        }
    
    File.WriteAllText(INILoc, newText);
                            //^^^^^^^ due to string.Empty it was storing empty string into file.
