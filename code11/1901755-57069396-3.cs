    public class Config : INotifyPropertyChanged
    {
        private string mycolor;
    
        public string MyColor
        {
            get { return mycolor; }
            set
            {
                mycolor = value;
                OnPropertyChanged("MyColor");
            }
        }
    
        public Config (){
            mycolor = "#00FF00"; // can set a defalut color here
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
