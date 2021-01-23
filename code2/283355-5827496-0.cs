    using System;
    using System.Linq;
    namespace stackoverflow.com_questions_5825629_select_topx_while_x_kind_value
    {
        class Program
        {
            static void Main()
            {
                var hsc1 = new SomeData { EffectiveDate = new DateTime(2011, 4, 5), Kind = "KindOne" };
                var hsc2 = new SomeData { EffectiveDate = new DateTime(2011, 4, 10), Kind = "KindTwo" };
                var hsc3 = new SomeData { EffectiveDate = new DateTime(2011, 4, 20), Kind = "KindOne" };
                var hsc4 = new SomeData { EffectiveDate = new DateTime(2011, 4, 25), Kind = "KindOne" };
    
                var all = new[] { hsc1, hsc2, hsc3, hsc4 };
    
                var lastSomeData = all.OrderByDescending((x) => x.EffectiveDate).First();
    
                var q = (from h in all
                         orderby h.EffectiveDate descending
                         select h).TakeWhile(x => x.Kind == lastSomeData.Kind);
    
                var result = q.ToArray();
    
                foreach (var item in result)
                    Console.WriteLine(item);
                Console.WriteLine("");
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
    
            // Define other methods and classes here
            class SomeData
            {
                public DateTime EffectiveDate { get; set; }
                public string Kind { get; set; }
                public override string ToString()
                {
                    return string.Format(@"new SomeData {{ EffectiveDate = new DateTime({0}, {1}, {2}), Kind = ""{3}"" }};", EffectiveDate.Year, EffectiveDate.Month, EffectiveDate.Day, Kind);
                }
            }
        }
    }
