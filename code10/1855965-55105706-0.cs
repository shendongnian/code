    public class C
    {
        public void WithoutIn(string s)
        {
            Console.WriteLine(s);
        }
        
        public void WithIn(in string s)
        {
            Console.WriteLine(s);
        }
    }
