    public class UnderTest
    {
        public UnderTest(IConsole console)
        {
            _console = console;
        }
        public void WriteLine()
        {
            _console.WriteLine("It works!");
        }
        readonly IConsole _console;
    }
