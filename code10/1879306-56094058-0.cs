    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                List<Village> villages = new List<Village>() {
                    new Village() { Id = 1, Name = "Chakwal", UnitType = UnitType.Dist},
                    new Village() { Id = 2, Name = "Choa", UnitType = UnitType.Tehsil},
                    new Village() { Id = 3, Name = "Dalwal", UnitType = UnitType.UC},
                    new Village() { Id = 4, Name = "Waulah", UnitType = UnitType.Village},
                    new Village() { Id = 5, Name = "DalPur", UnitType = UnitType.Village},
                    new Village() { Id = 6, Name = "Dulmial", UnitType = UnitType.UC},
                    new Village() { Id = 7, Name = "Tatral", UnitType = UnitType.Village},
                    new Village() { Id = 8, Name = "Arar", UnitType = UnitType.Village}
                };
                List<Population> populations = new List<Population>() {
                    new Population() { Id = 1, NoOfPerson = 20000},
                    new Population() { Id = 2, NoOfPerson = 20000},
                    new Population() { Id = 3, NoOfPerson = 14300},
                    new Population() { Id = 4, NoOfPerson = 9800},
                    new Population() { Id = 5, NoOfPerson = 4500},
                    new Population() { Id = 6, NoOfPerson = 5700},
                    new Population() { Id = 7, NoOfPerson = 3400},
                    new Population() { Id = 8, NoOfPerson = 2300}
                };
                var results = (from v in villages
                               join p in populations on v.Id equals p.Id
                               select new { v = v, p = p }
                              ).ToList();
                StreamWriter writer = new StreamWriter(FILENAME);
                writer.WriteLine("{0,25}","POPULATION");
                writer.WriteLine("{0,-5}{1,-8}{2,-14}{3,-10}", "Code", "Name", "Type", "Population");
                foreach (var result in results)
                {
                    writer.WriteLine("{0,-5}{1,-8}{2,-14}{3,-10}", result.v.Id.ToString(), result.v.Name, result.v.UnitType.ToString(), result.p.NoOfPerson.ToString());
                }
                writer.Flush();
                writer.Close();
              
            }
        }
        public enum UnitType
        {
            Village,
            UC,
            Tehsil,
            Dist
        }
        public class Village
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public UnitType UnitType { get; set; }
            public int? ParientId { get; set; }
            public Village Parient { get; set; }
        }
        public class Population
        {
            public int Id { get; set; }
            public int VillageId { get; set; }
            public Village Village { get; set; }
            public int NoOfPerson { get; set; }
        }
    }
