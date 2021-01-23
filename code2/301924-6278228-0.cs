    class WorkingContext
    { 
        public float Value; // you'll excuse me a public field here, I trust
        public override string ToString()
        {
            return Value.ToString();
        }
    }
    static void Main()
    {
        // start with some small magic number
        WorkingContext a = new WorkingContext(), temp = new WorkingContext();
        a.Value = 0.000000000000000013877787807814457f;
        for (; ; )
        {
            // add the small a to 1
            temp.Value = 1f + a.Value;
            // break, if a + 1 really is > '1'
            if (temp.Value - 1f != 0f) break;
            // otherwise a is too small -> increase it
            a.Value *= 2f;
            Console.Out.WriteLine("current increment: " + a);
        }
        Console.Out.WriteLine("Found epsilon: " + a);
        Console.ReadKey();
    }
