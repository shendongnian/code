        static void Main(string[] args) {
            if (!ErrorToBool(Method)) {
                Console.WriteLine("failed");
            } else if (!ErrorToBool(() => Method2(2))) {
                Console.WriteLine("failed");
            }
        }
        static void Method() {}
        static void Method2(int agr) {}
