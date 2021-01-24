    using System;
    using System.Collections.Generic;
    using Common;
    using Microsoft.CodeAnalysis.CSharp.Scripting;
    using Microsoft.CodeAnalysis.Scripting;
    
    public class Parameters
    {
        public string text;
    
        public Arguments arguments;
    }
    
    namespace CSharpScriptingExperiment
    {
        class Program
        {
            static void Main(string[] args)
            {   
                ScriptOptions options = ScriptOptions.Default.WithImports(new List<string>() { "Common" });
    
                options = options.AddReferences(typeof(Arguments).Assembly);
    
                // Script will compare the text inside arguments object to the text passed in via function parameters
                var script = CSharpScript.Create(@"
                    public class TestClass
                    {
                        public Output DoSomething(string text, object arguments)
                        {
                            Arguments args = (Arguments)arguments;
                            return new Output() { Success = args.Text == text };
                        }
                    }", options: options, globalsType: typeof(Parameters));
    
                var nextStep = script.ContinueWith<object>("return new TestClass().DoSomething(text, arguments);");
    
                // Setup the global paramters object
                Parameters parameters = new Parameters();
                parameters.text = "Hello";
                parameters.arguments = new Arguments()
                {
                    Text = "Hello"
                };
    
                // Run script
                Output output = (Output)nextStep.RunAsync(globals: parameters).Result.ReturnValue;
    
                Console.WriteLine(output.Success);
                Console.ReadLine();
            }
        }
    }
