                string[] inputs = { "NR105BE", "BD11AA" };
                foreach (string input in inputs)
                {
                    string output = "";
                    if (input.Length == 7)
                    {
                        output = input.Substring(0, 4) + " " + input.Substring(4);
                    }
                    else
                    {
                        output = input.Substring(0, 3) + " " + input.Substring(3);
                    }
                    Console.WriteLine(output);
                }
                Console.ReadLine();
