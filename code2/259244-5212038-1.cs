      public partial class MainWindow : Window, INotifyPropertyChanged
    {
     public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private string _my_text;
        string my_text
        {
            get { return _my_text; }
            set 
            { 
                _my_text = value;
                OnPropertyChanged("my_text");
            }
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            MainGrid.DataContext = this;
            MyUserControl.text = "This is a text";
            my_text = "Another text";  
        }
     }
