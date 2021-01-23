     static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            int k = 0;
            list.ForEach(delegate(int i) {  list[k++] = i+3; });
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
