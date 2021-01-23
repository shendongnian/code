     public class Program
        {
            public static void Main(string[] args)
            {
                List<MyData> list = new List<MyData>();
                // load the data (replace this with a loop over the file)    
                list.Add(new MyData { Key = "B", Value = 67 });
                list.Add(new MyData { Key = "C", Value = 45 });
                list.Add(new MyData { Key = "A", Value = 15 });
                list.Add(new MyData { Key = "D", Value = 10 });
    
                list.Sort();           
            }
        }
    
    
        internal class MyData : IComparable<MyData>
        {
            public string Key { get; set; }
            public int Value { get; set; }
            public int CompareTo(MyData other)
            {
                return other.Value.CompareTo(Value);
            }
    
            public override string ToString()
            {
                return Key + ":" + Value;
            }
        } 
