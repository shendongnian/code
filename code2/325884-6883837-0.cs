    class Program
    {
        static void Main(string[] args)
        {
            IBackend addon = new FooA();
            Console.WriteLine("Enter something if you like");
            var more = Console.ReadLine();
            var result = Runtime(addon);
            Console.WriteLine("Result: {0}", result ?? "No Output :o(");
        }
        static object Runtime(IBackend addon, string more = null)
        {
            var need = addon as INeed;
            if (need != null)
                need.Input = more;
            addon.Execute();
            var give = addon as IGive;
            if (give != null)
                return give.Output;
            return null;
        }
    }
    public interface IBackend
    {
        void Execute();
    }
    public interface INeed
    {
        string Input { set; }
    }
    public interface IGive
    {
        string Output { get; }
    }
    public class FooA : IBackend, INeed, IGive
    {
        public void Execute()
        {
            Console.WriteLine(this.Input ?? "No input :o(");
            if (!string.IsNullOrWhiteSpace(this.Input))
                this.Output = "Thanks!";
        }
        public string Input { private get; set; }
        public string Output { get; private set; }
    }
