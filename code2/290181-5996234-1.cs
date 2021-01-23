    class DoFile {
    
        static void Main(string[] args) {
            string templateString = @"
            {0}
            {1}
            {2}
            ";
            Console.WriteLine(templateString, "a", "b", "c");
        }
    }
