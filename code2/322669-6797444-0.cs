    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private string firstName
        public string FirstName
        {
            get { return this.firstName; }
            set 
            {
                if( this.firstName == value )
                {
                    return;
                }
    
                this.firstName = value;
                this.RaisePropertyChanged("FirstName");
                
            }
        } 
    
        private void RaisePropertyChanged(string propertyName)
        {
           if( this.PropertyChanged != null )
           {
               this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
           }
        }
    }
