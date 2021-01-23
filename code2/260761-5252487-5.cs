    public class TestSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string Name { get; set; }        
    }
    public class TestDestination : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Id { get; set; }    
    }
    class Program
    {        
        static void Main(string[] args)
        {
            var x = new TestSource();
            var y = new TestDestination();
            
            x.Bind<string, string>(Name => y.Id);
        }    
    }
