    static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            do
            {
                // Test with list
                watch.Reset(); watch.Start();
                List<Int32> test = GetList(500000);
                watch.Stop(); Console.WriteLine(watch.Elapsed.ToString());
                watch.Reset(); watch.Start();
                List<String> myList = RemoveTest(test);
                watch.Stop(); Console.WriteLine(watch.Elapsed.ToString());
                Console.WriteLine((500000 - test.Count).ToString());
                Console.WriteLine();
                // Test with HashSet
                watch.Reset(); watch.Start();
                HashSet<String> test2 = GetStringList(500000);
                watch.Stop(); Console.WriteLine(watch.Elapsed.ToString());
                watch.Reset(); watch.Start();
                HashSet<String> myList2 = RemoveTest(test2);
                watch.Stop(); Console.WriteLine(watch.Elapsed.ToString());
                Console.WriteLine((500000 - test.Count).ToString());
                Console.WriteLine();
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        static private List<Int32> GetList(int size)
        {
            List<Int32> test = new List<Int32>();
            for (int i = 0; i < 500000; i++)
                test.Add(i);
            return test;
        }
        static private HashSet<String> GetStringList(int size)
        {
            HashSet<String> test = new HashSet<String>();
            for (int i = 0; i < 500000; i++)
                test.Add(i.ToString());
            return test;
        }
        static private List<String> RemoveTest(List<Int32> list)
        {
            list.RemoveAll(t => t % 5 == 0);
            return list.ConvertAll(delegate(int i) { return i.ToString(); });
        }
        static private HashSet<String> RemoveTest(HashSet<String> list)
        {
            list.RemoveWhere(t => Convert.ToInt32(t) % 5 == 0);
            return list;
        }
