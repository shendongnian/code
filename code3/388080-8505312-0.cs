        class Program
        {
            static void Main(string[] args)
            {
                var temp = Execute(DoSomething);
                Console.Write(temp);
                Console.Read();
            }
    
            static int Execute(Func<int> methodToRun)
            {
                return methodToRun.Invoke();
            }
    
            static int DoSomething()
            {
                return 1;
            }
        }
