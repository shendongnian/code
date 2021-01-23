    using System;
    using System.IO;
    namespace listFoldersTest
    {
      class Program
      {
        private static bool foundIt;
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 50);
            try
            {
                DirectoryInfo dir = new DirectoryInfo(args[0]);
                getDirsFiles(dir, 0, 2);
            }
            catch
            {
            }
            Console.ReadKey();
            Console.WriteLine("done");
        }
        
        public static void getDirsFiles(DirectoryInfo d, int currentDepth, int maxDepth)
        {
            if(d == null || foundIt) return;
            String folderToFindName = ("albumName");
            if (currentDepth < maxDepth)
            {
                DirectoryInfo[] dirs = d.GetDirectories("*.*");
                foreach (DirectoryInfo dir in dirs)
                {
                    String pathName = (dir.FullName);
                    Console.WriteLine("\r{0} ", dir.Name);
                    if (currentDepth == (maxDepth - 1))
                    {
                        if (pathName.IndexOf(folderToFindName) != -1)
                        {
                            foundIt = true;
                            FileInfo[] files = dir.GetFiles("*.*");
                            foreach (FileInfo file in files)
                            {
                                Console.WriteLine("-------------------->> {0} ", file.Name);
                            } //end foreach files
                            return;
                        } // end if pathName
                    } // end if of get files current depth
                    getDirsFiles(dir, currentDepth + 1, maxDepth);
                } //end if foreach directories
            } //end if directories current depth
        } // end getDirsFiles function
      }
    }
