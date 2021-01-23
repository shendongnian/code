    public class Example
    {
        private const int foo = 5;
        private readonly Dictionary<string, string> bar = new Dictionary<int, string>();
    
        //.... missing stuff where bar is populated
    
        public void DoSomething()
        {
           Console.Writeline(bar[foo]);
    
           // when compiled the above line is replaced with Console.Writeline(bar[5]);
           // because at compile time the compiler can replace foo with 5
           // but it can't do anything inline with bar itself, as it is readonly
           // not a const, so cannot benefit from the optimization
        }
    }
