        [Test]
        public void TestString() {
            IList<string> strings = new List<string>();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int index = 0; index < 100000; index++) {
                string t = "1" + "2" + "3";
                // Keep the compiler from optimizing this away
                strings.Add(t);
            }
            watch.Stop();
            Console.WriteLine("string: " + watch.ElapsedMilliseconds);
            watch.Reset();
            watch.Start();
            for (int index = 0; index < 100000; index++) {
                StringBuilder b = new StringBuilder();
                b.Append("1").Append("2").Append("3");
                strings.Add(b.ToString());
            }
            watch.Stop();
            Console.WriteLine("StringBuilder: " + watch.ElapsedMilliseconds);
        }
