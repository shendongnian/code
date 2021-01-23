    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication3 {
        class Program {
            static void Main(string[] args) {
                string _data = @"Bosch SGS45A08GB Silver Dishwasher
                Bosch Avantixx SGS45A02GB Dishwasher, White
                Bosch SMS53E12GB White Dishwasher
                Bosch SGS45A08GB Dishwashers
                BOSCH SGI45E15E Full-size Semi-Integrated Dishwasher
                Bosch SKS60E02GB Compact Dishwasher, White
                BOSCH SRV43M03GB Slimline Integrated Dishwasher
                BOSCH Classixx SGS45C12GB Full-size Dishwasher - White
                BOSCH SGS45A02GB DishwashersBosch 18V Cordless Drill Driver
                Bosch PSB 18V Li-Ion Hammer Drill
                Bosch SGS45A08GB Dishwasher
                Bosch SGS45A08 12Place Full Size Dishwasher in Silver";
    
                Regex _expression = new Regex(@"\p{Lu}{3}\d+\w+\s+");
                foreach (Match _match in _expression.Matches(_data)) {
                    Console.WriteLine(_match.Value);
                }
                Console.ReadKey();
            }
        }
    }
