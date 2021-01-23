    class Program {
        static void Main(string[] args) {
            var foo = new Foo();
            const int count = 1000000;
            var sw = new Stopwatch();
            sw.Restart();
            for (int i = 0; i < count; ++i) {
                string name1 = foo.Field1Name;
                string name2 = foo.Field2Name;
            }
            sw.Stop();
            Console.Write("Cached:\t\t");
            Console.WriteLine(sw.Elapsed);
            sw.Restart();
            for (int i = 0; i < count; ++i) {
                string name1 = Foo.GetVariableName(() => foo.Field1);
                string name2 = Foo.GetVariableName(() => foo.Field2);
            }
            sw.Stop();
            Console.Write("Non-cached:\t");
            Console.WriteLine(sw.Elapsed);
        }
    }
