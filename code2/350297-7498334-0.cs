                string[] SourceFilez = System.IO.Directory.GetFiles("path", "*.*", System.IO.SearchOption.AllDirectories);
                string[] targetFilez = new string[SourceFilez.Length];
                SourceFilez.CopyTo( targetFilez, 0 );
    
                
                for(int i = 0; i < targetFilez.Length; ++i)
                {
                    targetFilez[i] = targetFilez[i].Replace("oldfolder", "newfolder");
    
                    string strThisDirectory = System.IO.Path.GetDirectoryName(targetFilez[i]);
    
    
                    if (!System.IO.Directory.Exists(strThisDirectory))
                    {
                        System.IO.Directory.CreateDirectory(strThisDirectory);
                    }
    
                    System.IO.File.Copy(SourceFilez[i], targetFilez[i]);
                }
