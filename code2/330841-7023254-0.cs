    // This is a simple customer class that 
    // implements the IPropertyChange interface.
    public class DemoCustomer  : INotifyPropertyChanged
    {
        // These fields hold the values for the public properties.
        private string customerNameValue = String.Empty;
        
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged(String info)
        {
            var listeners = PropertyChanged;
            if (listeners  != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
       
        public string CustomerName
        {
            get
            {
                return this.customerNameValue;
            }
    
            set
            {
                if (value != this.customerNameValue)
                {
                    this.customerNameValue = value;
                    NotifyPropertyChanged("CustomerName");
                }
            }
        }
    }
