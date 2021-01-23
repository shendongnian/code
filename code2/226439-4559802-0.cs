    public class LazyRecord : INotifyPropertyChanged
    {
      private string name;
      public string Name
      {
        get { return name; }
        set
        {
          if (name != value)
          {
             name = value;
             OnPropertyChanged("Name");
          }
        }
    
        // other properties
    
        // now the important stuff - deffering the update
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged(string propertyName)
        {
           if (this.changedProperties.Find(propertyName) == null)
            this.changedProperties.Add(propertyName);
        }
    
        private readonly List<string> changedProperties = new List<string>();
    
        // and the timer that refreshes the data
        private readonly Timer timer;
        private readonly Record record;
    
        public LazyRecord(Record record)
        {
           this.timer = new Timer(1000, OnTimer);
           this.record = record;
 
           this.record.OnPropertyChanged += (o, a) => this.OnPropertyChanged(a.PropertyName);
        }
    
        public void OnTimer(..some unused args...)
        {
           if (this.PropertyChanged != null)
           {
            foreach(string propNAme in changedProperties)
            {
               PropertyChanged(new PropertyChangedEventArgs(propName));
            }
        }
    }
