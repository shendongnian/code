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
                    OnPropertyChanged(nameof(Foo));
                }
            }
    
            public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                // Raise the PropertyChanged event, passing the name of the property whose value has changed.
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
    }
