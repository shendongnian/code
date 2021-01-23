    using System;
    using System.IO;
    using System.IO.Pipes;
    
    namespace TestNamedPipe
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var pipe = new NamedPipeServerStream("hello.txt"))
                {
                    pipe.WaitForConnection();
                    using (var writer = new StreamWriter(pipe))
                    {
                        writer.WriteLine("Hello, World!");
                    }
                }
            }
        }
    }
