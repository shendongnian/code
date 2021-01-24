string fileName = @"C:\Users\COURE-TECH\source\repos\FileSplitting\FileSplitting\dnd.txt";
            var fileSuffix = 0;
            int lines = 0;
            using (var file = File.OpenRead(fileName))
            using (var reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    Console.WriteLine("How many lines per file would you like to have?");
                    if (!int.TryParse(Console.ReadLine(), out lines))
                    {
                        Console.WriteLine("Write an integer value");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Done!!!");
                    }
                    string AllContent = reader.ReadToEnd();
                    List<string> AllNumbers = AllContent.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    var newLists = splitList(AllNumbers, lines);
                    foreach (var list in newLists)
                    {
                        string newFileName = $"{fileName}{(++fileSuffix)}.txt";
                        using (var tw = new StreamWriter(newFileName, true))
                        {
                            foreach (string phoneNumber in list)
                            {
                                tw.WriteLine(phoneNumber);
                            }
                        }
                    }
                }
            }
