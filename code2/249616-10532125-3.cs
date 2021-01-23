		[Test]
		public void ProofOfConcept2()
		{
			Evaluator evaluator = new Evaluator(new CompilerContext(new CompilerSettings(), new ConsoleReportPrinter()));
			evaluator.InteractiveBaseClass = typeof(Variables2);
			Variables.Variable1Callback = () => 5.1;
			Variables.Variable2Callback = () => 30;
			var result = evaluator.Evaluate(@"IF(25 + Variable1 > Variable2, ""TRUE"", ""FALSE"")");
			Assert.AreEqual("TRUE", result);
			Console.WriteLine(result);
		}
		public class Variables2 : Variables
		{
			public static T IF<T>(bool expr, T trueValue, T falseValue)
			{
				return expr ? trueValue : falseValue;
			}
		}
