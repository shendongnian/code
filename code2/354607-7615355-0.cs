    public partial class MyEntity
    {
    
        public MyEntity()
        {
            // Hook up PropertyChanged event to alert the UI
            // to update the Sum when any of the Values change
            this.PropertyChanged += MyEntity_PropertyChanged;
        }
    
        void MyEntity_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch e.PropertyName
            {
                case "Value1":
                case "Value2":
                case "Value3":
                    ReportPropertyChanged("SumValues");
                    break;
            }
        }
    
    
        public int SumValues
        {
            get
            {
                return Value1 + Value2 + Value3;
            }
        }
    
    }
