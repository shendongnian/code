    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<Some> items = new ObservableCollection<Some>();
            for (int i = 0; i < 10; i++)
            {
                items.Add(new Some(string.Format("passwordChar {0}", i + 1), string.Format("passwordText {0}", i + 1), Visibility.Visible, Visibility.Collapsed));
            }
            this.lbox.ItemsSource = items;
        }
        private void StackPanel_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Some some = (sender as StackPanel).DataContext as Some;
            some.TextBlockVisibility = ToggleVisibility(some.TextBlockVisibility);
            some.TextBoxVisibility = ToggleVisibility(some.TextBoxVisibility);
        }
        private Visibility ToggleVisibility(Visibility visibility)
        {
            return visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
    }
    public class Some:INotifyPropertyChanged
    {
        private string _passwordChar;
        private string _passwordText;
        private Visibility _textBlockVisibility, _textBoxVisibility;
        public string PasswordChar { get { return this._passwordChar; } set { this._passwordChar = value; } }
        public string PasswordText { get { return this._passwordText; } set { this._passwordText = value; } }
        public Visibility TextBlockVisibility 
        { 
            get { return this._textBlockVisibility; } 
            set 
            { 
                this._textBlockVisibility = value;
                RaisePropertyChanged("TextBlockVisibility");
            }
 
        }
        public Visibility TextBoxVisibility 
        { 
            get { return this._textBoxVisibility; }
            set 
            { 
                this._textBoxVisibility = value;
                RaisePropertyChanged("TextBoxVisibility");
            }
        }
        public Some(string passwordChar, string passwordText, Visibility textBlockVisibility, Visibility textBoxVisibility)
        {
            this._passwordChar = passwordChar;
            this._passwordText = passwordText;
            this._textBlockVisibility = textBlockVisibility;
            this._textBoxVisibility = textBoxVisibility;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
