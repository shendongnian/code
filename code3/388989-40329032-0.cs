    public void directoryCrawl(string startFolder)
        {
        try
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
            /* here you can add "dir" to some kind of list of your choice. */
            foreach (System.IO.DirectoryInfo directory in dir.GetDirectories())
            {
                try
                {
                    directoryCrawl(directory.FullName);
                }
                catch
                {
                    Console.Writeline("Access denied to: \"" + directory.FullName + "\".");
                }
            }
        }
        catch
        {
            if (!String.IsNullOrEmpty(startFolder))
            {
                Console.Writeline("Access denied to: \"" + startFolder + "\".");
            }
            }
            return;
        }
