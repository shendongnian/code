    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace CS_TestApp
    {
        class Program
        {
            struct Occurrence
            {
                public int Line { get; set; }
                public int Column { get; set; }
                public Occurrence(int line, int column) : this()
                {
                    Line = line;
                    Column = column;
                }
            }
    
            private static string[] ReadFileSafe(string fileName)
            {
                // If the file doesn't exist
                if (!File.Exists(fileName))
                    return null;
    
                // Variable that stores all lines from the file
                string[] res;
    
                // Try reading the entire file
                try { res = File.ReadAllLines(fileName, Encoding.UTF8); }
                catch (IOException) { return null; }
                catch (ArgumentException) { return null; }
    
                return res;
            }
    
            private static List<Occurrence> SearchFile(string[] file, string searchString)
            {
                // Create a list to store all occurrences of substring in the file
                List<Occurrence> occ = new List<Occurrence>();
                
                for (int i = 0; i < file.Length; i++) // Loop through all lines
                {
                    string line = file[i]; // Save the line
                    int totalIndex = 0; // The total index
                    int index = 0; // The relative index (the index found AFTER totalIndex)
                    while (true) // Loop until breaks
                    {
                        index = line.IndexOf(searchString, totalIndex); // Search for the index
                        if (index >= 0) // If a string was found
                        {
                            // Save the occurrence to our list
                            occ.Add(new Occurrence(i, totalIndex + index));
                            totalIndex += index + searchString.Length; // Add the total index and the searchString
                        }
                        else break; // If no more occurances found
                    }
                }
    
                // Here we have our list filled up now we can return it
                return occ;
            }
    
            private static void PrintFile(string[] file, List<Occurrence> occurences, int searchWordLength)
            {
                IEnumerator<Occurrence> enumerator = occurences.GetEnumerator();
                enumerator.MoveNext();
                for (int i = 0; i < file.Length; i++)
                {
                    string line = file[i];
                    do
                    {
                        if (enumerator.Current.Line == i)
                        {
                            Console.Write(line.Substring(0, enumerator.Current.Column));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(line.Substring(enumerator.Current.Column, searchWordLength));
                            Console.ResetColor();
                            line = line.Substring(enumerator.Current.Column + searchWordLength);
                        }
                        else break;
                    }
                    while (enumerator.MoveNext());
                    Console.WriteLine(line); // Write the rest
                }
            }
    
            private static bool WriteToFile(string file, List<Occurrence> occ)
            {
                StreamWriter sw;
                try { sw = new StreamWriter(file); }
                catch (IOException) { return false; }
                catch (ArgumentException) { return false; }
    
                try
                {
                    foreach (Occurrence o in occ)
                    {
                        // Write all occurences
                        sw.WriteLine("(" + (o.Line + 1).ToString() + "; " + (o.Column + 1).ToString() + ")");
                    }
    
                    return true;
                }
                finally
                {
                    sw.Close();
                    sw.Dispose();
                }
            }
    
            static void Main(string[] args)
            {
                bool anotherFile = true;
                while (anotherFile)
                {
                    Console.Write("Please write the filename of the file you want to search: ");
                    string file = Console.ReadLine();
                    Console.Write("Please enter the string to search for: ");
                    string searchString = Console.ReadLine();
    
                    string[] res = ReadFileSafe(file); // Call our search method
                    if (res == null) // If it either couldn't open the file, or the file didn't exist
                        Console.WriteLine("Couldn't open the read file.");
                    else // If the file was opened
                    {
                        Console.WriteLine();
                        Console.WriteLine("File:");
                        Console.WriteLine();
    
                        List<Occurrence> occ = SearchFile(res, searchString); // Search the file
                        PrintFile(res, occ, searchString.Length); // Print the result
    
                        Console.WriteLine();
    
                        Console.Write("Please enter the file you want to write the output to: ");
                        file = Console.ReadLine();
                        if (!WriteToFile(file, occ))
                            Console.WriteLine("Couldn't write output.");
                        else
                            Console.WriteLine("Output written to: " + file);
    
                        Console.WriteLine();
                    }
    
                    Pause("continue");
    
                requestAgain:
                    Console.Clear();
                    Console.Write("Do you want to search another file (Y/N): ");
                    ConsoleKeyInfo input = Console.ReadKey(false);
                    char c = input.KeyChar;
    
                    if(c != 'y' && c != 'Y' && c != 'n' && c != 'N')
                        goto requestAgain;
    
                    anotherFile = (c == 'y' || c == 'Y');
                    if(anotherFile)
                        Console.Clear();
                }
            }
    
            private static void Pause(string action)
            {
                Console.Write("Press any key to " + action + "...");
                Console.ReadKey(true);
            }
        }
    }
