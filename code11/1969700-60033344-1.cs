    public partial class MainPage : ContentPage
    {
        public ObservableCollection<imagemodel> images { get; set; }
        public Command command1 { get; set; }
        public MainPage()
        {
            InitializeComponent();
            images = new ObservableCollection<imagemodel>()
            {
                new imagemodel(){title="image 1"},
                new imagemodel(){title="image 2"},
                new imagemodel(){title="image 3"}
            };
            command1 = new Command<imagemodel>(commandpage);
            this.BindingContext = this;
        }
        private void commandpage(imagemodel m)
        {
            Console.WriteLine("the image model title is {0}",m.title.ToString());
        }
      
    }
    public class imagemodel
    {
        public string title { get; set; }
       
    }
