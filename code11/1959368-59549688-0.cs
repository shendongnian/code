     static void Main(string[] args)
        {
            string code = File.ReadAllText("D:\\Code.cs");
            CSScript.Evaluator.ReferenceAssembliesFromCode(code);
            dynamic block = CSScript.Evaluator.LoadCode(code);
            block.ExecuteAFunction();
            Console.ReadKey();
        }
