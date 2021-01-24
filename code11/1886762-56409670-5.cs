        static bool IsPalindrome(string s)
        {
            s = s.Replace(" ", "");
            s = s.Replace(",", "");
            s = s.Replace(":", "");
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                
                if (!char.ToLower(s[i]).Equals(char.ToLower(s[j])))
                    return false;
                i++;
                j--;
            }
            return true;
        }
