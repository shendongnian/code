        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"c:\System Volume Information");
            DirectoryInfo directoryInfo = null;
            foreach (var enumerateDirectories in di.GetDirectories("_restore*"))
            {
                if (directoryInfo == null || enumerateDirectories.CreationTime > directoryInfo.CreationTime)
                {
                    directoryInfo = enumerateDirectories;
                }
            }
            if (directoryInfo != null)
            {
                Console.WriteLine(directoryInfo.FullName);
            }
            Console.ReadLine();
        }
