    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp18
    {
        public class Reg
        {
            public string GID;
            public string name;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<Reg> youList = new List<Reg>();
                
                //Test data
                youList.Add(new Reg
                {
                    GID = "grp1",
                    name = "1"
                });
                youList.Add(new Reg
                {
                    GID = "grp1",
                    name = "1"
                });
                youList.Add(new Reg
                {
                    GID = "grp1",
                    name = "2"
                });
                youList.Add(new Reg
                {
                    GID = "grp2",
                    name = "1"
                });
                youList.Add(new Reg
                {
                    GID = "grp2",
                    name = "2"
                });
                youList.Add(new Reg
                {
                    GID = "grp3",
                    name = "3"
                });
                youList.Add(new Reg
                {
                    GID = "grp3",
                    name = "3"
                });
    
                var gruppedList = youList.Where(x => x.GID.Trim() != "").GroupBy(r => r.GID).Select(grp => new { A = grp.Key, B = grp.Select(r => r.name).ToList() }).ToList();
                var grpNameWhereNotUnique = gruppedList.Where(r => r.B.Count != r.B.Distinct().Count()).Select(r => r.A).ToList();
                Console.WriteLine(JsonConvert.SerializeObject(grpNameWhereNotUnique));
                Console.ReadKey();
            }
        }
    }
