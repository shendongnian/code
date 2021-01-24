        private static void CreateList()
        {
            List<Users> userList = new List<Users>();
            for (int i = 0; i != 2; i++)
            {
                Console.WriteLine("ADD NAME TO LIST: ");
                var names = Console.ReadLine();
                Console.WriteLine("ADD USER AGE: ");
                var age = Convert.ToInt32(Console.ReadLine());
                userList.Add(new Users(names, age));
            }
            Console.WriteLine("...");
            Console.ReadKey();
        }
