    public static bool AreStringsAnagrams(string a, string b)
        {
            bool anagram = true;
            if (!string.IsNullOrWhiteSpace(a) && !string.IsNullOrWhiteSpace(b) && a.Length == b.Length)
            {
                char[] ac = a.ToLower().ToCharArray();
                char[] bc = b.ToLower().ToCharArray();
                Array.Sort(ac);
                Array.Sort(bc);
                for (int i = 0; i < ac.Length; i++)
                {
                    if (ac[i] != bc[i])
                    {
                        anagram = false;
                        break;
                    }
                }
            }
            else
            {
                anagram = false;
            }
            return anagram;
        }
