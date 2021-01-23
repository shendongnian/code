    public class Discount
    {
        private DateTime _value;
        protected DateTime? ExpirationDate 
        {
            get { return _value; }
            set { 
                    _value = value; 
                    ExpirationDate = new OpenBusinessDate(value); 
                }
        }
        public OpenBusinessDate OpenExpirationDate {get; private set;}
    }
