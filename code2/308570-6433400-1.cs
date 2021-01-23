    public class MyClass
    {
        private volatile bool _theValue = false;
        public bool TheValue 
        {
            get { return _theValue; } 
            set { _theValue = value; } 
        }
     }
