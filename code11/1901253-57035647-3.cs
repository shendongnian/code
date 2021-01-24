    public class MyCalculator
    {
        public int Add(int a,int b)
        {
           return a + b;
        }
    }
     static void Main(string[] args)
     {
        ...
        var calculator = new MyCalculator();        
        var res = calculator.Add(num1, num2);
        Console.WriteLine(res);
     }
