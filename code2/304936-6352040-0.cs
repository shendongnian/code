    void DirSearch(string sDir, string relativeDir)
                {
                     int lst = sDir.LastIndexOf("\\") + 1;
                        string newRelative = relativeDir + d.Substring(lst, d.Length - lst) + "\\";
                    foreach (string f in Directory.GetFiles(sDir,txtfile.Text))
                        {
                            //doing something...
        
                            string outputPath = destinationDir + relativeDir + getFileNameFromPathString(f.ToString()) + ".jpg";
        
                            //doing more...
        
                        }
                    foreach (string d in Directory.GetDirectories(sDir))
                    {
                       
                       
                        //relativeDir = relativeDir + d.Substring(lst, d.Length - lst) + "\\";
                        DirSearch(d, newRelative);
                    }
                }
