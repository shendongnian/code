    public class MyDataContext : INotifyPropertyChanged 
    {
        private Brush color;
        public Brush Color
        {
            get { return color; }
            set
            {
                color = value;
                RaisePropertyChanged("Color");
            }
        }
        
        //implementation of PropertyChanged and RaisePropertyChanged omitted
    }
