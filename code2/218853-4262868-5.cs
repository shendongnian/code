    namespace INotifyChangedDemo
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            private int _hitCount;
            public int HitCount
            {
                get
                {
                    return _hitCount;
                }
                set
                {
                    if (_hitCount == value)
                        return;
    
                    _hitCount = value;
                    // Notify the listeners that Time property has been changed
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("HitCount"));
                    }
    
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
