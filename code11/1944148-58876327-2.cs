    class Program
        {
            static void Main(string[] args)
            {
                Action a2 = () => Third(50);
                a2.Invoke();
            }
            public static void Third(int x)
            {
                Console.WriteLine("Third invoked");
                int result;
                result = 3 + x;
                Console.WriteLine(result);
            }
            private static void SomeSpecialName()
            {
                Third(50);
            }
        }
