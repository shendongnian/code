            LinkedList<int> result = new LinkedList<int>();
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Array.Sort(array);
            bool odd = true;
            foreach (var x in array)
            {
                if (odd)
                    result.AddLast(x);
                else
                    result.AddFirst(x);
                odd = !odd;
            }
            foreach (int item in result)
                Console.Write("{0} ", item);
