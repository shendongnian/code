    class Program
    {
        public class HistoricValue
        {
            public string Name { get; set; }
            public DateTime Lastdate { get; set; }
            public Double Value { get; set; }
        }
        private static void Display(List<HistoricValue> cs)
        {
            Console.WriteLine();
            foreach (HistoricValue item in cs)
            {
                Console.WriteLine("{0} {1} {2} ", item.Name, item.Lastdate.ToString(), item.Value);
            }
        }
        static void Main(string[] args)
        {
            HistoricValue newValue  = new HistoricValue();
            List<HistoricValue> Historicals = new List<HistoricValue>();
            newValue.Name= "Some name 1";
            newValue.Lastdate = DateTime.Parse("2018-05-08");
            newValue.Value = 310.1;
            Historicals.Add(new HistoricValue () { Name=newValue.Name, Lastdate= newValue.Lastdate, Value = newValue.Value });
            Historicals.Add(newValue);
            Console.WriteLine("Expected output: Twice Some Name 1");
            Display(Historicals);
            newValue.Name = "Some name 2";
            newValue.Lastdate = DateTime.Parse("2018-09-09");
            newValue.Value = 210.1;
            Historicals.Add(new HistoricValue() { Name = newValue.Name, Lastdate = newValue.Lastdate, Value = newValue.Value });
            Historicals.Add(newValue);
            Console.WriteLine("\nExpected output: Twice Some Name 1 and twice somename 2");
            Display(Historicals);
            Console.WriteLine("\nReceived output: once Some name 1 and tree times somename 2");
            Console.WriteLine("\nnewValue get assigned values, what is stored in the list is the pointer to values, so item 2,3,4 will point to the same values in memory.");
    
            List<HistoricValue> Historicals2 = new List<HistoricValue>();
            Console.WriteLine("\nRCorrect ways to fill the list can be by using a constructor");
            Historicals2.Add(new HistoricValue() { Name = "Some name 1", Lastdate = DateTime.Parse("2018-05-08"), Value = 310.1 });
            Historicals2.Add(new HistoricValue() { Name = "Some name 2", Lastdate = DateTime.Parse("2018-06-08"), Value = 100.1 });
            Console.WriteLine("Expected output: Some Name 1 and Somename 2");
            Display(Historicals2);
            Console.WriteLine("\nOr add with specifically creating a new posistion in the list and add it.");
            newValue.Name = "Some name 3";
            newValue.Lastdate = DateTime.Parse("2018-05-08");
            newValue.Value = 310.1;
            Historicals2.Add(new HistoricValue() { Name = newValue.Name, Lastdate = newValue.Lastdate, Value = newValue.Value });
            newValue.Name = "Some name 4";
            newValue.Lastdate = DateTime.Parse("2018-09-09");
            newValue.Value = 999;
            Historicals2.Add(new HistoricValue() { Name = newValue.Name, Lastdate = newValue.Lastdate, Value = newValue.Value });
            Console.WriteLine("Expected output: Some Name 1,2,3 and 4");
            Display(Historicals2);
            Console.WriteLine("\nOr through using a loop in wich a variable is created and assiged and then stops living.");
            for( int x = 5; x<= 7; x++)
            {
                HistoricValue newValueInLoop = new HistoricValue();
                newValueInLoop.Name = "Some name " + x.ToString();
                newValueInLoop.Lastdate = DateTime.Parse("2018-09-09");
                newValueInLoop.Value = 999+x;
                Historicals2.Add(new HistoricValue() { Name = newValueInLoop.Name, Lastdate = newValueInLoop.Lastdate, Value = newValueInLoop.Value });
                //Display(Historicals2);
            }
            Console.WriteLine("Expected output: Some Name 1,2,3,4,5,6,7");
            Display(Historicals2);
            Console.WriteLine("Actually this is strange, realizing the variable only exists in the loop, yet the memory values are retainted, i hope the garbage collector works");
        }
    }
