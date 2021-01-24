    using System;
    using CodingSeb.ExpressionEvaluator;					
    public class Program
    {
    	public static void Main()
    	{
          string expression ="2 + Pow(3, 4) - 2";
    
    		ExpressionEvaluator evaluator = new ExpressionEvaluator();
    
    		Console.WriteLine("Result "+ evaluator.Evaluate(expression));
    	}
    }
