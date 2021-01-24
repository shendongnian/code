    public class ActionContainer
    {
        public Action Action { get; set; } = () => { };
    }
    class Program
    {
        static void Main(string[] args)
        {
            ActionContainer execute = new ActionContainer();
            ProgramTest prog = new ProgramTest(execute);
            prog.AddMethod();
            execute.Action();
        }
    }
    class ProgramTest
    {
        public ActionContainer execute;
        public ProgramTest(ActionContainer action)
        {
            execute = action;
        }
        public void AddMethod()
        {
            execute.Action += Print;
        }
        public void Print()
        {
            Console.WriteLine("test");
            Console.ReadLine();
        }
    }
