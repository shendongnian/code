        [TestMethod]
        public void Test1()
        {
            using (var package = new ExcelPackage())
            {
                package.Workbook.FormulaParserManager.LoadFunctionModule(new MyFunctionModule());
                var ws = package.Workbook.Worksheets.Add("Test");
                var cellTest = ws.Cells[1, 1];
                cellTest.Formula = "TRIM(\"Hello World\")";
                ws.Calculate();
                var cellCalculatedValue = cellTest.Value; //Will now show a proper value
            }
        }
        public class TrimFunction : ExcelFunction
        {
            public override CompileResult Execute(IEnumerable<FunctionArgument> arguments, ParsingContext context)
            {
                ValidateArguments(arguments, 1);
                var result = arguments.ElementAt(0).Value.ToString().Trim();
                return CreateResult(result, DataType.String);
            }
        }
        public class MyFunctionModule : FunctionsModule
        {
            public MyFunctionModule()
            {
                Functions.Add("trim", new TrimFunction());
            }
        }
