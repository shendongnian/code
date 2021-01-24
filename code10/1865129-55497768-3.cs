    using System;
						
	public class Program
	{
		public static void Main()
		{
			var result = new AssignmentNode("x", new AddNode(new ValueNode("y", 10), new ValueNode("z", 20)));
			Console.WriteLine(result.GetStringValue());
			
		}
	}
	public abstract class ArithmeticNode
	{
		public abstract double GetNumericValue();
		public abstract string GetStringValue();
	}
	public abstract class OperatorNode : ArithmeticNode
	{
		public ArithmeticNode Left { get; }
		public ArithmeticNode Right { get; }
		public string Symbol { get; }
		
		protected OperatorNode(ArithmeticNode left, ArithmeticNode right, string symbol)
		{
			Left = left;
			Right = right;
			Symbol = symbol;
		}
		
		protected abstract double Operate(double left, double right);
		
		public override double GetNumericValue()
		{
			return Operate(Left.GetNumericValue(), Right.GetNumericValue());	
		}
		
		public override string GetStringValue()
		{
			return string.Format("({0} {1} {2})", Left.GetStringValue(), Symbol, Right.GetStringValue());
		}
	}
	public class AddNode : OperatorNode
	{
		public AddNode(ArithmeticNode left, ArithmeticNode right)
			: base(left, right, "+") { }
			
		protected override double Operate(double left, double right)
		{
			return left + right;	
		}
	}
	public class ValueNode : ArithmeticNode
	{
		public string Name { get; }
		public double Value { get; }
		
		public ValueNode(string name, double value)
		{
			Name = name;
			Value = value;
		}
		
		public override double GetNumericValue()
		{
			return Value;
		}
		
		public override string GetStringValue()
		{
			return string.Format("{0}({1})", Name, Value);
		}
	}
	// Represents an expression assigned to a variable
	public class AssignmentNode : ArithmeticNode
	{
		public string Name { get; }
		public ArithmeticNode Body { get; }
		
		public AssignmentNode(string name, ArithmeticNode body)
		{
			Name = name;
			Body = body;
		}
		
		public override double GetNumericValue()
		{
			return Body.GetNumericValue();
		}
		
		public override string GetStringValue()
		{
			return string.Format("{0} = {1} = {2})", Name, Body.GetStringValue(), Body.GetNumericValue());
		}
	}
