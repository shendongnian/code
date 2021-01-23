       void RecursiveDirectorySearch(string sDir, string patternToMatch) 
            {
              // Where sDir would be the drive you want to search, I.E. "C:\"
              // Where patternToMatch has the extension, I.E. ".xml"
                try	
                {
                    foreach (string d in Directory.GetDirectories(sDir)) 
                    {
                        foreach (string f in Directory.GetFiles(d, txtFile.Text)) 
                        {
                           if(f.Contains(patternToMatch)
                            {
                              lstFilesFound.Items.Add(f);
                            }
                        }
                        DirSearch(d);
                    }
                }
                catch (System.Exception excpt) 
                {
                    Console.WriteLine(excpt.Message);
                }
            }
