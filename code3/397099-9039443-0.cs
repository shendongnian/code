    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            People = new ObservableCollection<string> {"Shawn", "steve", "Bob", "randy", "mike"};
            DataContext = this;
            InitializeComponent();
        }
        public ObservableCollection<string> People { get; set; }
        
        private void AutoCompleteBox_Populating(object sender, PopulatingEventArgs e)
        {
            // Have we already populated with this text?
            if(People.Any(person => person.ToLower().StartsWith(e.Parameter.ToLower()))) return;
            Completer c = new Completer();
            c.Completed += new EventHandler<EventArgs>(c_Completed);
            c.Complete(e.Parameter);
        }
        void c_Completed(object sender, EventArgs e)
        {
            Completer c = sender as Completer;
            foreach (var name in c.Names)
            {
                People.Add(name);       
            }
        }
    }
    internal class Completer
    {
        public event EventHandler<EventArgs> Completed;
        public IEnumerable<string> Names { get; set; }
        public void Complete(string parameter)
        {
            if (parameter.StartsWith("d"))
            {
                Names = new List<string>() { "Dick", "Dave" };
            }
            else if (parameter.StartsWith("j"))
            {
                Names = new List<string>() { "Jane", "Joe" };
            }
            OnCompleted();
        }
        protected virtual void OnCompleted()
        {
            var handler = Completed;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
