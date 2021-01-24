	using System;
						
	public class Program
	{
		public static void Main()
		{
			var result = new AssignmentNode("x", new AddNode(new ValueNode("y", 10), new ValueNode("z", 20)));
			Console.WriteLine(result.GetStringValue());
			
		}
	}
	public interface IArithmeticNode
	{
		double GetNumericValue();
		string GetStringValue();
	}
	public abstract class OperatorNode : IArithmeticNode
	{
		public IArithmeticNode Left { get; }
		public IArithmeticNode Right { get; }
		public string Symbol { get; }
		
		protected OperatorNode(IArithmeticNode left, IArithmeticNode right, string symbol)
		{
			Left = left;
			Right = right;
			Symbol = symbol;
		}
		
		protected abstract double Operate(double left, double right);
		
		public double GetNumericValue()
		{
			return Operate(Left.GetNumericValue(), Right.GetNumericValue());	
		}
		
		public string GetStringValue()
		{
			return string.Format("({0} {1} {2})", Left.GetStringValue(), Symbol, Right.GetStringValue());
		}
	}
	public class AddNode : OperatorNode
	{
		public AddNode(IArithmeticNode left, IArithmeticNode right)
			: base(left, right, "+") { }
			
		protected override double Operate(double left, double right)
		{
			return left + right;	
		}
	}
	public class ValueNode : IArithmeticNode
	{
		public string Name { get; }
		public double Value { get; }
		
		public ValueNode(string name, double value)
		{
			Name = name;
			Value = value;
		}
		
		public double GetNumericValue()
		{
			return Value;
		}
		
		public string GetStringValue()
		{
			return string.Format("{0}({1})", Name, Value);
		}
	}
	// Represents an expression assigned to a variable
	public class AssignmentNode : IArithmeticNode
	{
		public string Name { get; }
		public IArithmeticNode Body { get; }
		
		public AssignmentNode(string name, IArithmeticNode body)
		{
			Name = name;
			Body = body;
		}
		
		public double GetNumericValue()
		{
			return Body.GetNumericValue();
		}
		
		public string GetStringValue()
		{
			return string.Format("{0} = {1} = {2})", Name, Body.GetStringValue(), Body.GetNumericValue());
		}
	}
