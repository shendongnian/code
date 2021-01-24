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
        private Brush background= Brushes.White;
        public Brush Background
        {
            get { return background; }
            set { Background = value; NotifyPropertyChanged(Background); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
