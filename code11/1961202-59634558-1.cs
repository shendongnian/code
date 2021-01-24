     List<Owner> owners = new List<Owner>();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Please enter the employee name: ");
                string name  = Console.ReadLine();
                Console.WriteLine("Please enter the number of Properties Sold: ");
                int numProperties = int.Parse(Console.ReadLine());
                owners.Add(new Owner(name, numProperties));
            }
