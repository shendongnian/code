    public class Person : INotifyPropertyChanged
    {
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public ObservableCollection<AccountDetail> Details
        {
            get { return details; }
            set { details = value; }
        }
    
        public void AddDetail(AccountDetail detail) {
            details.Add(detail);
            OnPropertyChanged("Phones");
        }
    
        public IEnumerable<AccountDetail> Phones
        {
            get
            {
                return details.Where(d => d.Type == DetailType.Phone);
            }
        }
    
        private string firstName;
        private string lastName;
        private ObservableCollection<AccountDetail> details;
    
    
        /// <summary>
        /// Called when a property changes.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        #region INotifyPropertyChanged Members
    
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    
        #endregion
          
    }
