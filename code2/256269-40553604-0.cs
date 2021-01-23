    using System;
    using System.Collections.Generic;
    namespace StringDict
    {
        class Program
        {
            static IDictionary<char, int> charDict =new Dictionary<char, int>();
            static private string _charStr = "s;ldfjgsl;dkkjfg;lsdkfjg;lsdkfjg;lsdkfjg;lsdkfj";
            private static int _outInt=0;
            static void Main(string[] args)
            {
                foreach (var ch in _charStr)
                {
                    if (!charDict.TryGetValue(ch,out _outInt))
                    {
                        charDict.Add(new KeyValuePair<char, int>(ch,1));
                    }
                    else
                    {
                        charDict[ch]++;
                    }
                }
                Console.Write("Unique Characters: ");
                Console.WriteLine('\n');
                foreach (var kvp in charDict)
                {
                    Console.Write(kvp.Key);
                }
                Console.WriteLine('\n');
                foreach (var kvp in charDict)
                {
                    Console.WriteLine("Char: "+kvp.Key+" Count: "+kvp.Value);
                }
                Console.ReadLine();
            }
        }
    }
