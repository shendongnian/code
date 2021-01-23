            // Only get files that begin with the letter "c."
            string[] dirs = Directory.GetFiles(@"c:\", "c*");
            Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
            foreach (string dir in dirs) 
            {
                Console.WriteLine(dir);
            }
