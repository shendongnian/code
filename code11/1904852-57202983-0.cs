    public class Program
    {
        public static void Main()
        {
            var listA = new List<Foo>() {
                new Foo() { TableName = "Table A", Value = "Foo 1" },
                new Foo() { TableName = "Table B", Value = "Foo 1" },
            };
            
            var listB = new List<Foo>() {
                new Foo() { TableName = "Table A", Value = "Foo 10" },
                new Foo() { TableName = "Table C", Value = "Foo 12" },
            };
            
            foreach (var itemA in listA)
            {
                foreach (var itemB in listB)
                {
                    if (itemA.TableName == itemB.TableName)
                    {
                        Console.WriteLine($"ItemA's Value: {itemA.Value}");
                        Console.WriteLine($"ItemB's Value: {itemB.Value}");
                    }
                }
            }
        }
    }
    
    public class Foo
    {
        public string TableName { get; set; }
        public string Value { get; set; }
    }
