    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace testList
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write((int)'A');
                Console.Write((int)'Z');
                Console.WriteLine("Whats the starting string?");
                string start = Console.ReadLine().ToUpper();
                Console.WriteLine("Whats the end string?");
                string end = Console.ReadLine().ToUpper();
    
                List<string> retVal = new List<string>();
                retVal.Add(start);
    
                string currentString = start;
                while (currentString != end)
                {
                    currentString = IncrementString(currentString);
                    Console.WriteLine(currentString);
                    retVal.Add(currentString);
                }
                retVal.Add(end);
                Console.WriteLine("Done");
                Console.ReadKey();
            }
    
            private static string IncrementString(string currentString)
            {
                StringBuilder retVal = new StringBuilder(currentString);
                char endChar= currentString[currentString.Length - 1];
                for (int x = (currentString.Length - 1); x >= 0; x--)
                {
                    char c = currentString[x];
                    if (TryIncrementChar(ref c))
                    {
                        retVal[x] = c;
                        break;
                    }
                    else
                    {
                        retVal[x] = 'A';
                        if (x == 0)
                        {
                            retVal.Insert(0,'A');
                        }
                    }
                }
                return retVal.ToString();
    
            }
            private static bool TryIncrementChar(ref char currChar)
            {
                if (currChar != 'Z')
                {
                    currChar++;
                    return true;
                }
                return false;
            }
        }
    }
