            using(var reader = new StreamReader("MyFile.txt"))
            {
                string line;
                int lineNumber = 0;
                while((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    if (line.Contains("Toast"))
                    {
                        Console.WriteLine($"Found 'Toast' on line {lineNumber}");
                    }
                }
            }
