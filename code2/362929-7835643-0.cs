    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static string GetPartialPath(this string fullPath, string partialPath)
            {
                return fullPath.Substring(partialPath.Length)
            }
        }   
    }
