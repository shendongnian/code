    static void Main(string[] args)
    {
        try
        {
            string path = @"C:\test.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            //get original access time
            DateTime dt = File.GetLastAccessTime(path);
            Console.WriteLine("The last access time for this file was {0}.", dt);
            // Update the last access time.
            File.SetLastAccessTime(path, DateTime.Now);
            dt = File.GetLastAccessTime(path);
            Console.WriteLine("The last access time for this file was {0}.", dt);
            Console.Read();
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
