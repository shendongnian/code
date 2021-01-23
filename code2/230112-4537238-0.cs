    class Program
        {
            static void Main(string[] args)
            {
                var ent = new Entities(10);
                ent.PropertyChanged += new PropertyChangedEventHandler(ent_PropertyChanged);
                ent.iCounter = 100;
            }
    
            static void ent_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                throw new NotImplementedException();
            }
        }
    
    
        public class Entities : INotifyPropertyChanged
        {
    
            public Entities(int iCount)
            {
                _iCounter = iCount;
            }
            private int _iCounter;
            public int iCounter
            {
                get
                {
                    return _iCounter;
                }
                set
                {
                    _iCounter = value;
                    NotifyPropertyChanged("iCounter");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
        }
