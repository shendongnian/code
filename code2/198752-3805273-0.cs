    public static class StringExtensions
    {
        public static string Clean(this string str)
        {   
            string[] split = str.Split(' ');
    
            List<string> strings = new List<string>();
            foreach (string splitStr in split)
            { 
                if (splitStr.Length > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    bool tagOpened = false;
    
                    foreach (char c in splitStr)
                    {
                        int iC = (int)c;
                        if (iC > 32)
                        {
                            if (iC == 60)
                                tagOpened = true;
    
                            if (!tagOpened)
                                   sb.Append(c);
    
                            if (iC == 62)
                                tagOpened = false;
                        }
                    }
    
                    string result = sb.ToString();   
    
                    if (result.Length > 0)
                        strings.Add(result);
                }
            }
    
            return string.Join(" ", strings.ToArray());
        }
    }
