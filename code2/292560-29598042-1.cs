    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ExpressionEvaluator.Eval("(2 + 2) * 2"));
        }
    }
    public class ExpressionEvaluator
    {
        public static double Eval(string expression)
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            CompilerResults results =
                codeProvider
                .CompileAssemblyFromSource(new CompilerParameters(), new string[]
                {
                    string.Format(@"
                        namespace MyAssembly
                        {{
                            public class Evaluator
                            {{
                                public double Eval()
                                {{
                                    return {0};
                                }}
                            }}
                        }}
                    ",expression)
                });
            Assembly assembly = results.CompiledAssembly;
            dynamic evaluator = 
                Activator.CreateInstance(assembly.GetType("MyAssembly.Evaluator"));
            return evaluator.Eval();
        }
    }
