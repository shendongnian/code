    public class MySliderDataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public double AngleSlider 
        { 
           get { return _angle; }
           set 
           { 
               _angle = value;
               if(PropertyChanged != null)
                  PropertyChanged(this, new PropertyChangedEventArgs("AngleSlider"));
           }
         }           
    }
