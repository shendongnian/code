    public class ViewModel : INotifyPropertyChanged
    {
        public RelayCommand ColorChangerCommand { get; set; }
        public TreeViewModel() //Constructor of the View Model
        {
            ColorChangerCommand = new RelayCommand(ChangeColor);
        }
        public void ChangeColor(object sender)
        {
            this.Background = (sender as TreeViewItem).Foreground;
        }
        private Brush Background = Brushes.White;
        public Brush MyProperty
        {
            get { return Background; }
            set { Background = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
