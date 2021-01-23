    public class SomeClass
    {
        private bool _hasChanged = true;
        private string _previousString = null;
        
        public string MyString
        {
            get 
            {
                if (_hasChanged)
                {
                    _hasChanged = false;
                    _previousString = .... your complex string building logic ....
                } 
                return _previousString;
            }
        }
        public int OtherProperties
        {
            get { return _otherField; }
            set { _otherField = value; _hasChanged = true; }
        }
