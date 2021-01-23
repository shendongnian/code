        public static void Main(string[] args)
        {
            var arr1 = BuildArr(1000000);
            var arr2 = BuildArr(1000000);
            var arr3 = BuildArr(1000000);
            DoDirectToDisk(arr1, arr2, arr3);
            DoBuffered(arr1, arr2, arr3);
            DoWriteLines(arr1, arr2, arr3);
        }
        private static void DoWriteLines(string[] arr1, string[] arr2, string[] arr3)
        {
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100; i++)
            {
                File.WriteAllLines(@"C:\WriteLines.txt", arr1);
                File.AppendAllLines(@"C:\WriteLines.txt", arr1);
                File.AppendAllLines(@"C:\WriteLines.txt", arr1);
            }
            sw.Stop();
            Console.WriteLine("Write Lines {0}", sw.Elapsed);
        }
        
        private static void DoBuffered(string[] arr1, string[] arr2, string[] arr3)
        {
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100; i++)
            {
                using (var writer = new StringWriter())
                {
                    foreach (var item in arr1.Union(arr2).Union(arr3))
                        writer.WriteLine(item);
                    File.WriteAllText(@"C:\buffered.txt", writer.ToString());
                }
            }
            sw.Stop();
            Console.WriteLine("Buffered {0}", sw.Elapsed);
        }
        private static void DoDirectToDisk(string[] arr1, string[] arr2, string[] arr3)
        {
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100; i++)
                using (var writer = new StreamWriter(@"C:\Direct.txt"))
                {
                    foreach (var item in arr1.Union(arr2).Union(arr3))
                        writer.WriteLine(item);
                }
            sw.Stop();
            Console.WriteLine("Direct To Disk took {0}", sw.Elapsed);
        }
