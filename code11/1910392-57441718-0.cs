    static void Main(string[] args)
        {
            Dictionary<string, int> Directory = new Dictionary<string, int>();
            Console.WriteLine("Enter the Number of inputs");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter the Name " + i + 1 + " : ");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter the Age " + i + 1 + " : ");
                int Age = Convert.ToInt32(Console.ReadLine());
                Directory.Add(Name, Age);
            }
            Console.WriteLine("Press key to display the contents of your dictionary..");
            Console.ReadLine();
            foreach (var item in Directory)
            {
                Console.WriteLine("Name : " + item.Key);
                Console.WriteLine("Age : " + item.Value);
            }
            Console.ReadLine();
        }
