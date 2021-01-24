 class MyColor : INotifyPropertyChanged
 {        
        public event PropertyChangedEventHandler PropertyChanged;
        private Color _color;
        public Color color
        {
            get
            {
               return _color;
            }
            set
            {
               _color = value;
               OnPropertyChanged("color");
            }
        }
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
  }   
Instantiate the collection where appropriate.
   ObservableCollection<MyColor> ellipseColors = new ObservableCollection<MyColor>();
Then bind to the color property of your indexed MyColor object in the xaml.
Color= "{Binding Path=ellipseColors[0].color, IsAsync=True}"/>
Credit to this post for some of the ideas. https://stackoverflow.com/questions/5415858/binding-to-an-array-element
