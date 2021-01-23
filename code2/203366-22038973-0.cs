     public static string TrimSpacesBetweenString(string s)
        {
            var mystring  =s.RemoveTandNs().Split(new string[] {" "}, StringSplitOptions.None);
            string result = string.Empty;
            foreach (var mstr in mystring)
            {
                var ss = mstr.Trim();
                if (!string.IsNullOrEmpty(ss))
                {
                    result = result + ss+" ";
                }
            }
            return result.Trim();
        }
