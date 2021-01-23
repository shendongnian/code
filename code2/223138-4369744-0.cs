    using Microsoft.CSharp;
    using System;
    using System.CodeDom;
    
    class Test
    {
        static void Main()
        {
            var compiler = new CSharpCodeProvider();
            // Just to provde a point...
            var type = new CodeTypeReference(typeof(Int32));
            Console.WriteLine(compiler.GetTypeOutput(type)); // Prints int
        }
    }
