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
            var serializer = new DataContractSerializer(
                circularTest.GetType(), 
                null, 
                100, 
                false, 
                true, // <!-- that's the important bit and indicates circular references
                null
            );
            serializer.WriteObject(Console.OpenStandardOutput(), circularTest);
        }
    }
