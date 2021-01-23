     public static Dictionary<char, int> FirstOccurence(string str)
        {
            char[] strArr = str.ToCharArray();
            Dictionary<char, int> firstOccur = new Dictionary<char, int>();
            for (int i = 0; i < strArr.Length; i++)
            {
                if (!firstOccur.ContainsKey(strArr[i]))
                {
                    firstOccur[strArr[i]] = i;
                }
            }
            return firstOccur;
        }
