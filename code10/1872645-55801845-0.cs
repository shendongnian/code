            Console.WriteLine("Could you please insert a few numbers?");
            var input = Console.ReadLine();
            var numbers = new List<int>();
            foreach (var item in input.Split(','))
            {
                numbers.Add(Convert.ToInt32(item));
            }
            numbers.Sort();
            foreach (int item in numbers)
            {
                Console.WriteLine(item);
            }
