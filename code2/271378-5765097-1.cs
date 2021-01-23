    [TestFixture]
    class Class1
    {
        private Evaluator evaluator;
    
        public Class1()
        {
            var report = new Report(new ConsoleReportPrinter());
            evaluator = new Evaluator(new CompilerSettings(), report);
        }
    
        [Test]
        public void EXPR()
        {
            evaluator.Run("using System;");
    
            int sum = (int)evaluator.Evaluate("1+2;");
        }
    }
