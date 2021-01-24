            var code =
            @"    
            using System;
            class Program
            {
                static void Main(string[] args)
                {
                    Console.WriteLine(""Hello World"");
                    Console.ReadKey();
                }
                private void SayHello()
                {
                    Console.WriteLine(""Hello"");
                }
            }";
        var visitor = new FsVisitor();
        visitor.Visit(CSharpSyntaxTree.ParseText(code).GetCompilationUnitRoot());
        Console.WriteLine(visitor.ToString());
