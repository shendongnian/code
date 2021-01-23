    public class CircularTest
    {
        public CircularTest[] Children { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var circularTest = new CircularTest();
            circularTest.Children = new[] { circularTest };
            var settings = new JsonSerializerSettings 
            { 
                PreserveReferencesHandling = PreserveReferencesHandling.Objects 
            };
            var json = JsonConvert.SerializeObject(circularTest, Formatting.Indented, settings);
            Console.WriteLine(json);
        }
    }
