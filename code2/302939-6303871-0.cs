    public class A
    {
        public void Execute()
        {
            Thread.Sleep(1000 * 3);
        }
    }
    
    class Program
    {
        static void Main()
        {
            var a = new A();
            Action del = (() => a.Execute());
            var result = del.BeginInvoke(state =>
            {
                ((Action)state.AsyncState).EndInvoke(state);
                Console.WriteLine("finished");
            }, del);
            Console.ReadLine();
        }
    }
