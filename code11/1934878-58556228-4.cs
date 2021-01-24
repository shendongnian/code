    public class Safety : INotifyPropertyChanged
        {
            private int id;
            public int ID
            {
                get
                {
                    return id;
                }
                set
                {
                    id = value;
                    this.RaisePropertyChange(nameof(ID));
                }
            }
    
            private int year;
            public int Year
            {
                get
                {
                    return year;
                }
                set
                {
                    year = value;
                    this.RaisePropertyChange(nameof(ID));
                }
            }
    
            private int quarter;
            public int Quarter
            {
                get
                {
                    return quarter;
                }
                set
                {
                    quarter = value;
                    this.RaisePropertyChange(nameof(ID));
                }
            }
    
            private string name;
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                    this.RaisePropertyChange(nameof(ID));
                }
            }
    
            private int safetyScore;
    
            public int SafetyScore
            {
                get
                {
                    return safetyScore;
                }
                set
                {
                    safetyScore = value;
                    this.RaisePropertyChange(nameof(ID));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void RaisePropertyChange(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
