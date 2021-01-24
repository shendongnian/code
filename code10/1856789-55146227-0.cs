    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp2
    {
        class Program
        {
            public static List<CsvOne> InitCsvOne()
            {
                //mock pulling in data
                List<CsvOne> csv = new List<CsvOne>
            {
                new CsvOne { dim1 = 2,dim2 = "wwa", field1 =3 },
                new CsvOne { dim1 = 1, dim2 = "arr", field1 = 6}
            };
                return csv;
            }
            public static List<CsvTwo> InitCsvTwo()
            {
                //mock pulling in data
                List<CsvTwo> csv = new List<CsvTwo>
            {
                new CsvTwo { dim1 = 2,dim2 = "jaja", field2 = 1000, field3 =2 },
                new CsvTwo { dim1 = 3, dim2 = "waa", field2 = 1000, field3 = 3 },
                new CsvTwo { dim1 = 1, dim2 = "arr", field2 = 2000, field3 = 4},
            };
                return csv;
            }
            
            static void Main(string[] args)
            {
                var csvOne = InitCsvOne();
                var csvTwo = InitCsvTwo();
                var csvThree = new List<CsvThree>();
                //get the ball rolling with csv one
                csvOne.ForEach(record =>csvThree.Add(new CsvThree(record)));
                //now either match up one with two or add with field1 being 0
                //if we already have a matching dim1 and dim2, lets update the two new fields.
                //note that we do not add another one if there are two the same
                csvTwo.ForEach(record =>
               {  
                   if (csvThree.Any(t => (t.dim1 == record.dim1 && t.dim2 == record.dim2)))
                       {
                           //combine the match with fields 2 and 3
                           var theMatch = csvThree.FirstOrDefault(t => (t.dim1 == record.dim1 && t.dim2 == record.dim2)); 
                           theMatch.field2 = record.field2;
                           theMatch.field3 = record.field3;
                       }
                       else //add this new record to the list
                       {
                           csvThree.Add(new CsvThree(record));
                       }
                });
                csvThree = csvThree.OrderBy(t => t.dim1).ThenBy(t=>t.dim2).ToList(); //or whatever you want
                //check it 
                Console.WriteLine($"Csv One Records");
                Console.WriteLine($" dim1|dim2|field1");
                csvOne.ForEach(record =>
                {
                    Console.WriteLine(record.ToString());
                });
                Console.WriteLine($"Csv Two Records");
                 Console.WriteLine($"dim1|dim2|field2|field3");
                csvTwo.ForEach(record =>
                {
                    Console.WriteLine(record.ToString());
                });
                Console.WriteLine($"Csv Three Records");
                Console.WriteLine($"dim1|dim2|field1|field2|field3");
                csvThree.ForEach(record =>
                {
                    Console.WriteLine(record.ToString());
                });
                Console.WriteLine("Press any key to exit...");
                var wait = Console.ReadKey();
            }
        }
        public abstract class dim
        { 
            public int dim1 { get; set; }
            public string dim2 { get; set; }
        }
        public class CsvOne:dim
        {
            public int field1 { get; set; }
            public CsvOne()
            {
                field1 = 0;
            } 
            public override string ToString()
            {
                return $"{dim1}  |{dim2}|{field1}";
            }
        }
        public class CsvTwo:dim
        {
            public int field2 { get; set; }
            public int field3 { get; set; }
            public CsvTwo()
            {
                field2 = field3 = 0;
            }
            public override string ToString()
            {
                return $"{dim1}  |{dim2}|{field2}|{field3}";
            }
        }
        public class CsvThree : dim
        {
            public int field1 { get; set; }
            public int field2 { get; set; }
            public int field3 { get; set; }
            public CsvThree()
            {
                field1 = field2 = field3 = 0;
            }
            public CsvThree(CsvOne value)
            {
                field1 = field2 = field3 = 0;
                dim1 = value.dim1;
                dim2 = value.dim2;
                field1 = value.field1;
            }
            public CsvThree(CsvTwo value)
            {
                field1 = field2 = field3 = 0;
                dim1 = value.dim1;
                dim2 = value.dim2;
                field2 = value.field2;
                field3 = value.field3;
            }
            public override string ToString()
            {
                return $"{dim1}  |{dim2}|{field1}|{field2}|{field3}";
            }
        }
    }
