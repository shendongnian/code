    if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
                else
                {
                    Console.WriteLine("");
                }
                //Create File 1
                if (!File.Exists(Person1Path))
                {
                    string[] DefaultData1 = { "Person 1", "0" };
                    File.WriteAllLines(Person1Path, DefaultData1);
                }
                else
                {
                    Console.WriteLine("");
                }
                //Create File 2
                if (!File.Exists(Person2Path))
                {
                    string[] DefaultData2 = { "Person 2", "0" };
                    File.WriteAllLines(Person2Path, DefaultData2);
                }
                else
                {
                    Console.WriteLine("");
                }
                //Create File 3
                if (!File.Exists(Person3Path))
                {
                    string[] DefaultData3 = { "Person 3", "0" };
                    File.WriteAllLines(Person3Path, DefaultData3);
                }
                else
                {
                    Console.WriteLine("");
                }
                //Create File 4
                if (!File.Exists(Person4Path))
                {
                    string[] DefaultData4 = { "Person 4", "0" };
                    File.WriteAllLines(Person4Path, DefaultData4);
                }
                else
                {
                    Console.WriteLine("");
                }
                //Create File 5
                if (!File.Exists(Person5Path))
                {
                    string[] DefaultData5 = { "Person 5", "0" };
                    File.WriteAllLines(Person5Path, DefaultData5);
                }
                else
                {
                    Console.WriteLine("");
                }
