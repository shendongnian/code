    class Program
    {
        static void Main(string[] args)
        {
            List<FileInfo> files = new List<FileInfo>();
            IEnumerable<FileInfo> result = files.Where(f => f.Extension.AnyOf(".jpg", ".gif"));
        }
    }
    public static class Extensions
    {
        public static bool AnyOf(this string extension, params string[] allowed)
        {
            return allowed.Any(a=>a.Equals(extension));
        }
    }
