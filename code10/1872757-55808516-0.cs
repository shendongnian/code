    using (StreamReader reader = new StreamReader(FilePath.Text))
                    {
                        // We read the file then we split it.
                        string lines = reader.ReadToEnd();
                        string[] splittedArray = lines.Split(',');
    
                        // We will check here if any of the strings is empty (or just whitespace).
                        foreach (string currentString in splittedArray)
                        {
                            if (currentString.Trim() != "")
                            {
                                // If the string is not empty then we add to our temporary list.
                                temp.Add(currentString);
                            }
                        }
    
                        // We have our splitted strings in temp List.
                        // If you need an array instead of List, you can use ToArray().
                        finalArray = temp.ToArray();
         }
