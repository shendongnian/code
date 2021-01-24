    using Newtonsoft.Json;
    using System;
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string jsonString = @"
    [
        [   {   item1: { 'id':      'Name'      },
                item2: { 'spec':    'More Data' }
            },
            {   item1: { 'id':      'Name'      },
                item2: { 'spec':    'More Data' }
            }
        ]
    ]";
                dynamic jsonObj = JsonConvert.DeserializeObject(jsonString);
                foreach (dynamic row in jsonObj)
                {
                    Console.WriteLine($"Row\n{row}\n--------------------");
                    foreach (var column in row)
                    {
                        Console.WriteLine($"Column\n{column}\n--------------------");
                        foreach (var item in column)
                        {
                            Console.WriteLine($"item\n{item}\n--------------------");
                            foreach (var part in item)
                            {
                                Console.WriteLine($"part\n{part}\n--------------------");
                                foreach (var subpart in part)
                                {
                                    Console.WriteLine($"subpart\n{subpart}\n--------------------");
                                    foreach (var subsubpart in subpart)
                                    {
                                        Console.WriteLine($"subsubpart\n{subsubpart}\n--------------------");
                                    }
                                }
                            }
                        }
                    }
                }
                Console.ReadKey();
            }
        }
    }
