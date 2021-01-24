 c#
 Dictionary<string, int> users = new Dictionary<string, int>();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Please enter the employee name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Please enter the number of Properties Sold: ");
                int number = int.Parse(Console.ReadLine());
                users.Add(name, number);
             }
            var data = users.OrderByDescending(a => a.Value).ToList();
            foreach (var i in data)
            {
                Console.WriteLine(i.Key+" "+i.Value);
            }
