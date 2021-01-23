    class Program
    {
        static FileStream CreateFileWithUniqueName(string folder, string fileName, 
            int maxAttempts = 1024)
        {
            // get filename base and extension
            var fileBase = Path.GetFileNameWithoutExtension(fileName);
            var ext = Path.GetExtension(fileName);
            for (var index = 0; index < maxAttempts; index++)
            {
                // first try with the original filename, else try incrementally adding an index
                var name = (index == 0)
                    ? fileName
                    : String.Format("{0} ({1}){2}", fileBase, index, ext);
                // build full path
                var fullPath = Path.Combine(folder, name);
                // check if exists using File.Exists() as this is much quicker
                // than opening the stream and catching the exception
                if (File.Exists(fullPath))
                    continue;
                // try to open the stream
                try
                {
                    return new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write);
                }
                catch (DirectoryNotFoundException) { throw; } // these two exceptions derive from IOException
                catch (DriveNotFoundException) { throw; }
                catch (IOException) { } // will be thrown if file exists
            }
            throw new Exception("Could not create unique filename");
        }
        static void Main(string[] args)
        {
            // example: create 20 uniquely named files
            for (var i = 0; i < 20; i++)
            {
                using (var stream = CreateFileWithUniqueName(@"c:\temp\", "test.txt"))
                {
                    Console.WriteLine("Created \"" + stream.Name + "\"");
                }
            }
            Console.ReadKey();
        }
    }
