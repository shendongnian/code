    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.DataContext = new CData();
            ThisCheckBox.ClearValue(CheckBox.IsCheckedProperty);
            //next will work only after clear binding
            ThisCheckBox.IsChecked = true;
        }
    }
    public class CData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isTrue;
        public bool IsTrue
        {
            get { return _isTrue; }
            set
            {
                if (_isTrue != value)
                {
                    _isTrue = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("IsTrue"));
                }
            }
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
