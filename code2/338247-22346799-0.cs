    public static class Extensions
    {
        public static string RemoveTabbing(this string fmt)
        {
            return string.Join(
                System.Environment.NewLine,
                fmt.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(fooline => fooline.Trim()));
        }
    }
