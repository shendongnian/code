    class MainClass
    {
        private static string person;
        public static void Main (string[] args) 
        {
            CreateName();
            Console.WriteLine(person);
        }
        static void CreateName()
        {
            Console.Write("Enter a name: ");
            person = Console.ReadLine(); 
        }
    }
