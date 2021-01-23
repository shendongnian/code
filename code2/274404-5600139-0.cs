    string fileContent = Resources.Users;
    
                using (var writer = new StringWriter(fileContent))
                {
                    string line = "<name>" + "|" + "<last>";
    				writer.WriteLine(line );                
                }
