     public string WildcardToRegex(string pattern)
            {
                          
                string result= Regex.Escape(pattern).
                    Replace(@"\*", ".+?").
                    Replace(@"\?", "."); 
    
                if (result.EndsWith(".+?"))
                {
                    result = result.Remove(result.Length - 3, 3);
                    result += ".*";
                }
    
                return result;
            }
