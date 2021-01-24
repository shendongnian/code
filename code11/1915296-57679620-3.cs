     namespace App1
    {
        public sealed partial class MainPage : Page
        {
            public TextModel ViewModel { get; set; }
    
            public MainPage()
            {
                ViewModel = new TextModel();
                this.InitializeComponent();
            }
        }
    
        public class TextModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            private string foo = "hello";
            public string Foo
            {
                get => foo;
    
                set
                {
                    foo = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Foo"));
                }
            }
    
        }
    
    }
