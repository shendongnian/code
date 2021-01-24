    var tree = CSharpSyntaxTree.ParseText(@"
        public class MyClass {
                int Method1() { return 0; }
                void Method2()
                {
                    int x = Method1();
                }
            }
        }");
    var Mscorlib = PortableExecutableReference.CreateFromAssembly(typeof(object).Assembly);
    var compilation = CSharpCompilation.Create("MyCompilation",
        syntaxTrees: new[] { tree }, references: new[] { Mscorlib });
    var model = compilation.GetSemanticModel(tree);
    //Looking at the first invocation
    var invocationSyntax = tree.GetRoot().DescendantNodes().OfType<InvocationExpressionSyntax>().First();
    var invokedSymbol = model.GetSymbolInfo(invocationSyntax).Symbol; //Same as MyClass.Method1
    //Get name
    var name = invokedSymbol.ToString();
    //Get class
    var parentClass = invokedSymbol.ContainingType;
    //Get assembly 
    var assembly = invokedSymbol.ContainingAssembly;
