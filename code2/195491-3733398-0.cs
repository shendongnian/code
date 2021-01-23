    public static void MakeList(string s)
            {
    
                string PATTERN = @"(?<=\.)[^{]*(?=\{)";
                
                s = s.Replace("\r", "").Replace("\n", "").Replace(" ","");
                var matches = Regex.Matches(s, PATTERN);
                var styleList = new List<string>();
                
                
                for (int i = 0; i < matches.Count; i++)
                {
                    
                    styleList.Add(matches[i].ToString());
                }
            }
