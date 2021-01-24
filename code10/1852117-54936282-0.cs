    using KVPS = System.Collections.Generic.KeyValuePair<string, string>;
    namespace Test 
    {
        class Program
        {
            static void Main(string[] args)
            {
                Tuple<KVPS, KVPS> a =
                    Tuple.Create(
                        new KVPS("a", "1"),
                        new KVPS("b", "2")
                        );
                Console.WriteLine($"{a.Item1.Key} {a.Item1.Value} : {a.Item2.Key} {a.Item2.Value}");
    		}
    	}
    }	
