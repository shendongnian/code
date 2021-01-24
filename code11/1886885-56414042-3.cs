    string[] lines = File.ReadAllLines(INILoc); //Considering INILoc is a string variable which contains file path.
    StringBuilder newText = new StringBuilder();
    bool containsSearchResul = false;
    
    foreach (string line in lines)
        {
           newText.Append(line);
           newText.Append(Environment.NewLine); //This will add \n after each line so all lines will be well formatted
           
           //Adding line to new text before if condition check will add "name" into file
           if (line.Contains("[names]"))
                  break;
           
        }
    
    File.WriteAllText(INILoc, newText.ToString());
                            //^^^^^^^ due to string.Empty it was storing empty string into file.
