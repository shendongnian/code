    class StrClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = null;
        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    
        private string receivedString;
        public string ReceivedString
        {
            get;
            set
            {
                string oldStr = receivedString;
                receivedString = value;
                PropertyChanged(receivedString, new PropertyChangedEventArgs("ReceivedString"));
            }
        }
    
        public void receiveData(string str)
        {
            //event fires here
            ReceivedString = str;
        }
    }
    
    class HandlerObject
    {
        public void HandlerMethod1(string s)
        {
            //magic
        }
    
        public void HandlerMethod2(string s)
        {
            //different kind of magic
        }
    }
    
    class Program
    {
        static void HandlerMethod3(string s)
        {
            //another kind of magic!
        }
    
        static void Main(string[] args)
        {
            StrClass class1 = new StrClass();
            StrClass class2 = new StrClass();
            StrClass class3 = new StrClass();
    
            HandlerObject handler = new HandlerObject();
    
            class1.PropertyChanged += (s, e) => { handler.HandlerMethod1(s.ToString()); };
            class2.PropertyChanged += (s, e) => { handler.HandlerMethod2(s.ToString()); };
            class3.PropertyChanged += (s, e) => { HandlerMethod3(s.ToString()); };
        }
    }
