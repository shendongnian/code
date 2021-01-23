    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace CS_TestApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Please write the filename of the file you want to search: ");
                string file = Console.ReadLine();
                Console.Write("Please enter the string to search for: ");
                string searchString = Console.ReadLine();
                Console.Clear();
                if (!File.Exists(file))
                {
                    Console.WriteLine("Couldn't find the file.");
                    Pause("exit");
                    return;
                }
                string[] res;
                try
                {
                    res = File.ReadAllLines("test.txt", Encoding.UTF8);
                }
                catch (IOException)
                {
                    Console.WriteLine("Couldn't open file.");
                    Pause("exit");
                    return;
                }
                for (int i = 0; i < res.Length; i++)
                {
                    string line = res[i];
                    int totalIndex = 0;
                    int index = 0;
                    while (true)
                    {
                        index = line.IndexOf(searchString, totalIndex);
                        if (index >= 0) // If a string was found
                        {
                            // Output where the string was found. Remove the + 1 from (totalIndex + index + 1) and from (i + 1) if you want to show the zero based position.
                            Console.WriteLine("String found at line: " + (i + 1).ToString() + ", position: " + (totalIndex + index + 1).ToString());
                            totalIndex += index + searchString.Length;
                        }
                        else break; // If no occurances found
                    }
                }
                Pause("exit");
            }
    
            private static void Pause(string action = "continue")
            {
                Console.Write("Press any key to " + action + "...");
                Console.ReadKey(true);
            }
        }
    }
