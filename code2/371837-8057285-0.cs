    public class BidirectionalMap<T1,T2>
    {
        public void Remove(T1 item) {}
        public void Remove(T2 item) {}
        public static void Test()
        {
            //This line compiles
            var possiblyBad = new BidirectionalMap<string, string>();
            //This causes the compiler to fail with an ambiguous invocation
            possiblyBad.Remove("Something");
        }
    }
