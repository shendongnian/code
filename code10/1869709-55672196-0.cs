    using System.ComponentModel;
    
    namespace zzWpfApp1
    {
        [TypeConverter(typeof(EnumDescriptionTypeConverter))]
        public enum ReaderType
        {
            [Description("Super Chief")] Chief,
            [Description("Super Staff")] Staff,
            [Description("super Officer")] Officer,
        }
        public class User : INotifyPropertyChanged
        {
            private string _name;
            private ReaderType _readerType;
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
    
            public ReaderType ReaderType
            {
                get { return _readerType; }
                set
                {
                    _readerType = value;
                    NotifyPropertyChanged("ReaderType");
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
