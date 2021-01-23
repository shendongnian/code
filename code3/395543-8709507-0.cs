    class Program
    {
        public string Name = "a name";
        static void Main(string[] args)
        {
            Name = "Hello"; //You can't do this, compile error
            Program p = new Program();
            p.Name = "Hi"; //You can do this
            
            SecondName = "Sn"; //You can do this
            Program.SecondName = "Tr"; //You can do this too
        }
        public static string SecondName = "Peat";
    }
