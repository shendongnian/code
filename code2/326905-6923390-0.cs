    public class MyClass
    {
        [DataMember]
        private string Name = "";
        public string _Name
        {
            get
            {
                return RegionNameName;
            }
            set
            {
                RegionNameName = value;
                this.NotifyPropertyChanged("_Name");
            }
        }
        
    }
