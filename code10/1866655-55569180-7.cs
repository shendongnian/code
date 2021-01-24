    using System.ComponentModel;
    
    namespace zzWpfApp1
    {
        [TypeConverter(typeof(EnumDescriptionTypeConverter))]
        public enum HairColor
        {
            [Description("White")] White,
            [Description("Black")] Black,
            [Description("Brown")] Brown,
            [Description("Red")] Red,
            [Description("Yellow")] Yellow,
        }
    
        class User : INotifyPropertyChanged
        {
            private string _name;
            private HairColor _haircolor;
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
    
            public HairColor HairColor
            {
                get { return _haircolor; }
                set
                {
                    _haircolor = value;
                    NotifyPropertyChanged("HairColor");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
