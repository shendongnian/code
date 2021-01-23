    [Serializable]
    public class Foo
    {
        public decimal Value;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            decimal d1 = decimal.Parse("1.0000");
            decimal d2 = decimal.Parse("1.00");
    
            Debug.Assert(d1 ==d2);
    
            var foo1 = new Foo() {Value = d1};
            var foo2 = new Foo() {Value = d2};
                
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, d1);
            stream.Close();
    
            formatter = new BinaryFormatter();
            stream = new FileStream("data.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            decimal deserializedD1 = (decimal)formatter.Deserialize(stream);
            stream.Close();
    
            Debug.Assert(d1 == deserializedD1);
    
            Console.WriteLine(d1); //1.0000
            Console.WriteLine(d2); //1.00
            Console.WriteLine(deserializedD1); //1.0000
    
            Console.Read();
        }
    }
