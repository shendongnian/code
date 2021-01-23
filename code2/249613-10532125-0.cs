	using System;
	using System.Diagnostics;
	using Mono.CSharp;
	using NUnit.Framework;
	public class MonoExpressionEvaluator
	{
		[Test]
		public void ProofOfConcept()
		{
			Evaluator evaluator = new Evaluator(new CompilerContext(new CompilerSettings(), new ConsoleReportPrinter()));
			evaluator.InteractiveBaseClass = typeof (Variables);
			Variables.Variable1Callback = () => 5.1;
			Variables.Variable2Callback = () => 30;
			var result = evaluator.Evaluate("25 + Variable1 > Variable2");
			Assert.AreEqual(25 + Variables.Variable1 > Variables.Variable2, result);
			Console.WriteLine(result);
		}
		public class Variables
		{
			internal static Func<double> Variable1Callback;
			public static Double Variable1 { get { return Variable1Callback(); } }
			internal static Func<double> Variable2Callback;
			public static Double Variable2 { get { return Variable2Callback(); } }
		}
	}
