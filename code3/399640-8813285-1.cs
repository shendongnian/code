        class Program
        {
    
            public static void SayHelloXTimes(string helloString, int x)
            {
                for (int i = 0; i < x; i++)
                {
                    Console.WriteLine(helloString);
                }
            }
    
            static void Main(string[] args)
            {
                MethodInfo Method = typeof(Program).GetMethod("SayHelloXTimes");
                Method.Invoke(null, new object[] { "foo", 3 });
    
                Console.ReadLine();
            }
        }
