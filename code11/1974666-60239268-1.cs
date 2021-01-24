    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    namespace ConsoleApp2
    {
        public class Program
        {
            public class Mapping
            {
                public char Sort { get; set; }
                public List<string> Homonyms { get; set; }
            }
    
            static void Main()
            {
                bool areTheSame = true;
                var string1 = "There are seas";
                var string2 = "Their are sees";
                //var s1 = "The bee is by the sea".Split(' ').Select(x => x.ToLower()).ToArray();
                //var s2 = "The sea is by the bee".Split(' ').Select(x => x.ToLower()).ToArray();
    
                var s1 = "There are seas".Split(' ').Select(x => x.ToLower()).ToArray();
                var s2 = "Their are sees".Split(' ').Select(x => x.ToLower()).ToArray();
    
                List<string> homonyms = File.ReadAllLines(@"path to your text file\TextFile1.txt").ToList();
                List<Mapping> mapping = new List<Mapping>();
    
                foreach (string item in homonyms)
                {
                    var g = item.Split('/');
                    Mapping element = new Mapping();
                    element.Sort = g[0].ToUpper()[0];
                    element.Homonyms = new List<string>();
                    element.Homonyms.AddRange(g.Select(x => x.ToLower()).ToList());
    
                    mapping.Add(element);
                }
    
                Console.WriteLine("Analising...{0} and {1}", string1,string2);
    
                for (int i = 0; i < s1.Count(); i++)
                {
                    string wordString1 = s1[i];
                    string wordString2 = s2[i];
                    Console.WriteLine("Word '{0}' and word '{1}'", wordString1, wordString2);
    
                    if (wordString1 != wordString2)
                    {
                        //check whether they are Homonyms
                        var sort = wordString1.ToUpper()[0];
                        var potentiallHomonym = mapping.Where(item => item.Sort == sort && item.Homonyms.Contains(wordString1)).ToList().FirstOrDefault();
    
                        if (potentiallHomonym != null)
                        {
                            if (potentiallHomonym.Homonyms.Contains(wordString2))
                            {
                                Console.WriteLine("Those words are Homonyms, enter to continue analising.");
                                Console.ReadLine();
                            }
                            else
                            {
                                areTheSame = false;
                                Console.WriteLine("Those words are not Homonyms.");
                                Console.ReadLine();
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Those words are the same");
                        Console.ReadLine();
                    }
                }
    
                if (areTheSame)
                {
                    Console.WriteLine("The strings are the same");
                }
    
                else
                {
                    Console.WriteLine("The strings are not the same");
                }
    
                Console.ReadLine();
            }
        }
    }
