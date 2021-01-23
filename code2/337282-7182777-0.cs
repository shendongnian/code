    // Defines an extended version of the ErrorProvider
    public class ExtendedErrorProvider : ErrorProvider, INotifyPropertyChanging, INotifyPropertyChanged
    {
        // That will replace the SetIconAlignment from the base class when you call it from outside the class
        public void SetIconAlignment(Control control, ErrorIconAlignment value)
        {
            // Will raise an event just before changing the property
            OnPropertyChanging("IconAlignment");
            // Changed the property using the base class
            base.SetIconAlignment(control, value);
            // Will raise an event just after the property has changed
            OnPropertyChanged("IconAlignment");
        }
        // This will ensure that whenever you bind methods to be called on the PropertyChanging, they will get called for the specific property...
        protected void OnPropertyChanging(string property) { if (PropertyChanging != null) PropertyChanging(this, new PropertyChangingEventArgs(property)); }
        public event PropertyChangingEventHandler PropertyChanging;
        // This will ensure that whenever you bind methods to be called on the PropertyChanged, they will get called for the specific property...
        protected void OnPropertyChanged(string property) { if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property)); }
        public event PropertyChangedEventHandler PropertyChanged;
    }
