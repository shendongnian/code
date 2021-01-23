    public class SomeObject
    {
        public SomeInnerObject1 Cat { get; set; }
        public SomeInnerObject2 Dog { get; set; }
    
        public class SomeInnerObject1
        {
            private int _Int = 0;
            public int Int {
                get
                {
                    return _Int;
                }
                set
                {
                    if(value < 0) 
                        throw new Exception("Int must be greater than or equal to 0.");
                    else
                        _Int = value;
                }
           }
    
            public string String
            {
                get
                {
                    return Int.ToString();
                }
            }
        }
    
        public class SomeInnerObject2
        {
            private string _BirthDayString = "";
            public string BirthDayString
            {
                get
                {
                    return _BirthDayString;
                }
                set
                {
                    DateTime newDate;
                    if(DateTime.TryParse(value, newDate))
                        BirthDay = newDate;
                    else
                        throw new ArgumentException("Birthday string must be a properly formatted date.");
                }
            }
    
            private DateTime _BirthDay = DateTime.MinValue;
            public DateTime BirthDay
            {
                get 
                {
                    return _BirthDay;
                }
                private set
                {
                    _BirthDay = value;
                }
            }
        }
    }
