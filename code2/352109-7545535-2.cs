    [Serializable]
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
            var formatter = new BinaryFormatter();
            using (var stream = File.Create("serialized.bin"))
            {
                formatter.Serialize(stream, circularTest);
            }
    
            using (var stream = File.OpenRead("serialized.bin"))
            {
                circularTest = (CircularTest)formatter.Deserialize(stream);
            }
        }
    }
