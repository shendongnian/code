        delegate int MyDelegate(int n);
        static void MyMethod(int n, params MyDelegate[] handlers)
        {
            for (int i = 0; i < handlers.Length; i++)
            {
                if (handlers[i] == null)
                    throw new ArgumentNullException("handlers");
                Console.WriteLine(handlers[i](n));
            }
        }
        static void Main(string[] args)
        {
            MyMethod(1, x => x, x => x + 1);
            Console.Read();
        }
