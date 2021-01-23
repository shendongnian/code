    List<int> number = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = number.Where(x => x % 2 == 0);
            number.Add(20);
            //foreach (int item in result)
            //{
            //    Console.WriteLine("loop1:" + item);
            //}
            foreach (int item in result)
            {
                if (item == 4)
                    break;
                Console.WriteLine("loop2:" + item);
            }
            number.Add(40);
            foreach (int item in result)
            {
              
                Console.WriteLine("loop3:"+item);
            }
            Console.ReadLine();
