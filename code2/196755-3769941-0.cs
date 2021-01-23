        public static string GetCommonStartingSubString(IList<string> strings)
        {
            if (strings.Count == 0)
                return "";
            if (strings.Count == 1)
                return strings[0];
            int charIdx = 0;
            while (IsCommonChar(strings, charIdx))
                ++charIdx;
            return strings[0].Substring(0, charIdx);
        }
        private static bool IsCommonChar(IList<string> strings, int charIdx)
        {
            if(strings[0].Length <= charIdx)
                return false;
            for (int strIdx = 1; strIdx < strings.Count; ++strIdx)
                if (strings[strIdx].Length <= charIdx 
                 || strings[strIdx][charIdx] != strings[0][charIdx])
                    return false;
            return true;
        }
