                var x = new int[] { 1, 2, 3, 4, 5 };
            var y = x as IList<int>;
            Console.WriteLine("The IList:" + string.Join(",", y));
            try
            {
                y.RemoveAt(1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine(string.Join(",", y));
