            string outFile = @"C:\Temp\test.txt";
            bool isAppend = true;
            ArrayList dirList = new ArrayList();
            dirList.Add("foo");
            dirList.Add("bar");
            dirList.Add("baz");
            if(File.Exists(outFile))
            {
                Console.WriteLine("Output file already exists...");
                Console.WriteLine("Type 'x' to overwrite or any other to append.");
                ConsoleKeyInfo cki = Console.ReadKey();
                isAppend = (cki.Key != ConsoleKey.X);
            }
            using (StreamWriter writer = new StreamWriter(outFile, isAppend))
            {
                foreach (var obj in dirList)
                {
                    writer.WriteLine(obj);
                }
            }
