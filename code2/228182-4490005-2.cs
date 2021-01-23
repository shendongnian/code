    public static class Statics1
    {
        public static string Value1 { get; set; }
        static Statics1()
        {
            Console.WriteLine("Statics1 cctor");
            Value1 = "Initialized 1";
        }
    }
