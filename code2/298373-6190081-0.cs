    interface IOutputStrategy
    {
        void Output(string message);
    }
    
    class ConsoleOutput:IOutputStrategy
    {
        public void Output(string message)
        {
            Console.Writeline(message);
        }
    }
    
    class FormOutput:IOutputStrategy
    {
        public void Output(string message)
        {
            // output where you want
        }
    }
