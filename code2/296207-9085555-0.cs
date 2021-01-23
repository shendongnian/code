    public List<string> listDir(string pPath)
            {
                List<string> dirList = new List<string>();
                listDir(pPath, dirList);
                return dirList;
            }
    private void listDir(string pPath, List<string> pList)
            {
                    string[] loDirs = System.IO.Directory.GetDirectories(pPath);
                    foreach (string loDir in loDirs)
                    {
                        pList.Add(loDir);
                        listDir(loDir, pList);
                    }
            }
