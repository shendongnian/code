            var code = 
            @"using System; 
            using System.Collections.Generic; 
            using System.Linq; 
            using System.Text; 
 
            namespace HelloWorld 
            { 
                class Program 
                { 
                    static void Main(string[] args) 
                    { 
                        Console.WriteLine(""Hello, World!""); 
                    } 
                } 
            }";
            var text = new StringText(code);
            SyntaxTree tree = SyntaxTree.ParseCompilationUnit(text);
            var index = code.IndexOf("}");
            var added = @"    Console.WriteLine(""jjfjjf""); 
                          ";
            var code2 = code.Substring(0, index) + 
                        added +
                        code.Substring(index);
            var text2 = new StringText(code2);
            var tree2 = tree.WithChange(text2, new [] { new TextChangeRange(new TextSpan(index, 0), added.Length) } );
            foreach (var span in tree2.GetChangedSpans(tree))
            {
                Console.WriteLine(text2.GetText(span));
            }
