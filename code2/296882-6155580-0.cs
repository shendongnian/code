    public class YourViewModel 
    {
        public YourViewModel()
        {
            AspectRatio.PropertyChanged += AspectRatio_PropertyChanged;
        }
        void AspectRatio_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
                NotifyPropertyChanged("ResolutionList");
        }        
    }
