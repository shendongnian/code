    System.Collections.ObjectModel.Collection<string> resultDirs=new System.Collections.ObjectModel.Collection<string> ();
                foreach (string  dir in System.IO.Directory.GetDirectories("path"))
                {
                    if (!dir.Contains("-")) resultDirs.Add(dir);
                }
