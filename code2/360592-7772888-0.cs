    public static class MyExtensions{
            public static string SubText(this System.String str, System.Int32 charCount, System.String continues) {
                if (string.IsNullOrWhiteSpace(str) || str.Length < charCount)
                    return str;
                str = str.Substring(0, charCount);
                int i = str.LastIndexOf(" ");
                if (i >= 0)
                    str = str.Remove(i);
                str = String.Concat(str, continues);
                return str;
            }
    }
