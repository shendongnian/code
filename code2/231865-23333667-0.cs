    public class FunctionTest
    {
        
        void Main()
        {
            Action doSomething;
        
            doSomething = FirstFunction;
            doSomething();
        
            doSomething = SecondFunction;
            doSomething();
        }
        
        void FirstFunction()
        {
            Console.Write("Hello, ");
        }
        
        void SecondFunction()
        {
            Console.Write("World!\n");
        }
    }
