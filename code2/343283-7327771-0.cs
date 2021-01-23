            var list = new List<object>();
            int capacity = list.Capacity;
            Console.WriteLine("Initial capacity: {0}", list.Capacity);
            for (int i = 0; i < 10000; i++)
            {
                list.Add(new object());
                if (list.Capacity > capacity)
                {
                    capacity = list.Capacity;
                    Console.WriteLine("Capacity is {0} when count is {1}", list.Capacity, list.Count);
                }
