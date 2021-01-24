    public class ViewModel01
    {
        private readonly Guid _id;
        public ViewModel01()
        {
            _id = Guid.NewGuid();
            Console.WriteLine($"Constructing {_id}");
        }
        ~ViewModel01()
        {
            Console.WriteLine($"Destructing {_id}");
        }
        public ObservableCollection<MyType> MyProperty;
    }
    static void Main(string[] args)
    {
        var model102 = new ViewModel02();
        GC.Collect(); // Force GC to collect garbage
        Console.ReadKey();
    }
