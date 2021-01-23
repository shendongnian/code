    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(JoinPaths(@"C:\ol\il\ek", @"ek\mek\gr"));
            Console.WriteLine(JoinPaths(@"C:\ol\il\ek", @"il\ek\mek\gr"));
            Console.WriteLine(JoinPaths(@"C:\ol\il\ek", @"ol\il\ek\mek\gr"));
            Console.ReadLine();
        }
        public static T[] Slice<T>(this T[] source, int start, int end)
        {
            if (end < 0)
                end = source.Length + end;
            var len = end - start;
            var res = new T[len];
            for (var i = 0; i < len; i++)
                res[i] = source[i + start];
            return res;
        }
        
        private static string JoinPaths(string path1, string path2)
        {
            var parts1 = path1.ToLower().Split(new char[] { '\\' });
            var parts2 = path2.ToLower().Split(new char[] { '\\' });
            
            int commonPartLen = 1;
            while (commonPartLen<parts1.Length && commonPartLen<parts2.Length)
            {
                string slice1 = string.Join("\\", parts1.Slice(parts1.Length - commonPartLen, parts1.Length ));
                string slice2 = string.Join("\\", parts2.Slice(0, commonPartLen));
         
                if (slice1 == slice2)
                {
                    for (var i = 0; i < commonPartLen; i++)
                        parts2[i] = "";
                    break;
                }
                commonPartLen++;
            }
            string firstPath = string.Join("\\", parts1.Where(a => !string.IsNullOrEmpty(a)));
            string secondPath = string.Join("\\", parts2.Where(a => !string.IsNullOrEmpty(a)));
            return firstPath + "\\"+secondPath; ;
        }
    }
