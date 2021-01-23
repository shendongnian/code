        private List<ScanDir> history = new List<ScanDir>();
        private ScanDir LastDir;
        private List<ScanItem> newList = new List<ScanItem>();
        public void Search(List<ScanItem> allItems) //adds files that contain foo
        {
            bool updateLastDir = false;
            foreach(ScanItem s in allItems)
            {
                if (updateLastDir)
                {
                    history = (from a in history
                               select a).Distinct().ToList();
                    LastDir = null;
                    for (int i = history.Count - 1; i >= 0; i--)
                    {
                        if (history[i].FullPath == Directory.GetParent(s.FullPath).ToString())
                        {
                            LastDir = history[i];
                            break;
                        }                        
                    }
                    
                    updateLastDir = false;                                        
                }
                if (s.IsDirectory)
                {
                    var temp = new ScanDir { FullPath = s.FullPath, IsDirectory = true, comparePath = s.comparePath, Attributes = s.Attributes };
                    if (LastDir == null)
                    {
                        newList.Add(temp);                        
                    }
                    else
                    {
                        LastDir.Items.Add(temp);
                        
                    }
                    LastDir = temp;
                    history.Add(LastDir);
                    Search(((ScanDir)s).Items);
                    history.RemoveAt(history.Count - 1);
                    updateLastDir = true;
                      
                }
                else
                {
                    if (s.Name.Contains("Foo")) // then add it
                    {
                        if (LastDir == null)                        
                            newList.Add(s);                        
                        else                        
                            LastDir.Items.Add(s);                       
                    }
                }
            }
        }
