    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using Microsoft.CSharp;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var p = new CSharpCodeProvider())
                {
                    var r = new CodeTypeReference(typeof(Dictionary<string, int>));
                    
                    Console.WriteLine(p.GetTypeOutput(r));
                }
            }
        }
    }
