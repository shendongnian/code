        static bool IsPalindrome(string s)
        {
            s = s.Replace(" ", "");
            s = s.Replace(",", "");
            s = s.Replace(":", "");
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                if (s[i].ToString().ToLower() != s[j].ToString().ToLower())
                    return false;
                i++;
                j--;
            }
            return true;
        }
