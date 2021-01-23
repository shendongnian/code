    public string RevString()
            {
                var s = "TestThisString";
                StringBuilder sb = new StringBuilder();
                var arr = s.ToCharArray();
    
                foreach (var c in arr)
                {
                    if (c.ToString() == c.ToString().ToLower())
                    { sb.Append(c.ToString().ToUpper());}
                    else
                    { sb.Append(c.ToString().ToLower()); }
                }
                return sb.ToString();
            }
