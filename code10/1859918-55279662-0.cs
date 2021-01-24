        public string ExtractIDFromFileName(string filename)
        {
            return filename.Split('_').Last();
        }
        public Dictionary<string,int> GetDictOfIDCounts()
        {
            List<string> allfiles = Directory.GetFiles("C:/Users/ngallouj/Desktop/Script/test", "*.txt").Select(Path.GetFileNameWithoutExtension).ToList();
            allfiles.AddRange(Directory.GetFiles("C:/Users/ngallouj/Desktop/Script/test", "*.top").Select(Path.GetFileNameWithoutExtension).ToList());
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach(var x in allfiles)
            {
                string fileID = ExtractIDFromFileName(x);
                if (dict.ContainsKey(fileID))
                {
                    dict[fileID]++;
                }
                else
                {
                    dict.Add(fileID, 1);
                }
            }
            return dict;
        }
