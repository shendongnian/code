    public class Addition : IOperation
    {
    	public int Operate(int a, int b){ return a + b; }
    }
    public class Subtraction : IOperation
    {
    	public int Operate(int a, int b){ return a - b; }
    }
    public class Multiplication : IOperation
    {
    	public int Operate(int a, int b){ return a * b; }
    }
