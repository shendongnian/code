    public static class StringBuilderExtension
    {
        public static string SubsituteString(this string OriginalStr, int index, int length, string SubsituteStr)
        {
            return new StringBuilder(OriginalStr).Remove(index, length).Insert(index, SubsituteStr).ToString();
        }
    }
