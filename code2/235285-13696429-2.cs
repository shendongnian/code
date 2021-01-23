    class Program
    {
        static FileStream CreateFileWithUniqueName(string folder, string fileName, 
            int maxAttempts = 1024)
        {
            // get filename base and extension
            var fileBase = Path.GetFileNameWithoutExtension(fileName);
            var ext = Path.GetExtension(fileName);
            // build hash set of filenames for performance
            var files = new HashSet<string>(Directory.GetFiles(folder));
            for (var index = 0; index < maxAttempts; index++)
            {
                // first try with the original filename, else try incrementally adding an index
                var name = (index == 0)
                    ? fileName
                    : String.Format("{0} ({1}){2}", fileBase, index, ext);
                // check if exists
                var fullPath = Path.Combine(folder, name);
                if(files.Contains(fullPath))
                    continue;
                // try to open the stream
                try
                {
                    return new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write);
                }
                catch (DirectoryNotFoundException) { throw; }
                catch (DriveNotFoundException) { throw; }
                catch (IOException) { } // ignore this and try the next filename
            }
            throw new Exception("Could not create unique filename in " + maxAttempts + " attempts");
        }
        static void Main(string[] args)
        {
            for (var i = 0; i < 500; i++)
            {
                using (var stream = CreateFileWithUniqueName(@"c:\temp\", "test.txt"))
                {
                    Console.WriteLine("Created \"" + stream.Name + "\"");
                }
            }
            Console.ReadKey();
        }
    }
