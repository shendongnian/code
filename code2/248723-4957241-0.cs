    class Program
        {
            static void Main(string[] args)
            {
                Dictionary<A, int> d = new Dictionary<A, int>();
                for (int i = 1; i <= 10; i++)
                {
                    d.Add(new A { Hash = i}, i);
                }
                DictionaryTest(5, d);
            }
    
            public static void DictionaryTest(int i, Dictionary<A, int> dict)
            {
                A key = dict.Keys.ToList()[i];
                key.Hash = 4;
                Console.WriteLine(dict[key].Equals(dict.Values.ToList()[i]));
                Console.ReadKey();
            }
        }
    
        public class A
        {
            public int Hash { get; set; }
    
            public override bool Equals(object obj)
            {
                return this.GetHashCode() == obj.GetHashCode();
            }
            public override int GetHashCode()
            {
                return Hash;
            }
        }
