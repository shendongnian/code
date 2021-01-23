            string s0 =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor\r\n" +
                "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud\r\n" +
                "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor\r\n" +
                "in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint\r\n" +
                "occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\r\n";
            StringStream ss0 = new StringStream(s0);
            StringStream ss1 = new StringStream();
            int line = 1;
            Console.WriteLine("Contents of input stream: ");
            Console.WriteLine();
            using (StreamReader reader = new StreamReader(ss0))
            {
                using (StreamWriter writer = new StreamWriter(ss1))
                {
                    while (!reader.EndOfStream)
                    {
                        string s = reader.ReadLine();
                        Console.WriteLine("Line " + line++ + ": " + s);
                        writer.WriteLine(s);
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Contents of output stream: ");
            Console.WriteLine();
            Console.Write(ss1.ToString());
