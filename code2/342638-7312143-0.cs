     public static void Main() {
                var s = Stopwatch.StartNew();
                Random r = new Random();
                for (int i = 0; i < 100000000; i++) {
                    int compute = ComputeColorDelta(r.Next(255), r.Next(255));
                }
                Console.WriteLine(s.ElapsedMilliseconds);
                Console.ReadLine();
            }
