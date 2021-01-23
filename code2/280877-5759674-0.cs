    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new List<string>();
            var list2 = new List<string>();
            for (int i = 0; i < 10000; i++)
            {
                list1.Add("Some very very very very very very very long email" + i);
                list2.Add("Some very very very very very very very long email" + i);
            }
            var timer = new Stopwatch();
            timer.Start();
            list1.SequenceEqual(list2);
            timer.Stop();
            Console.WriteLine(timer.Elapsed);
            Console.ReadKey();
        }
    }
