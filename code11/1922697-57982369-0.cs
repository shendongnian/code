    public delegate void ExDelegate(string value);
    class Program
    {
        static void Main(string[] args)
        {
            Connection connection = new Connection();
            connection.ExDelegate += OnConnection_ExDelegate;
            connection.Init();
        }
        public static void OnConnection_ExDelegate(string value)
        {
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
    public class Connection
    {
        public event ExDelegate ExDelegate;
        public void Init()
        {
            Console.Write("Enter your name: ");
            ExDelegate?.Invoke(Console.ReadLine());
        }
    }
