    public class EmailNotification
    {
        private IDateTimeWrapper _dateTimeWrapper = new DateTimeWrapper();
    
        public IDateTimeWrapper DateTimeWrapper 
        {
            get
            {
                return _dateTimeWrapper;
            }
            set
            {
                _dateTimeWrapper = value ?? throw new ArgumentNullException(nameof(DateTimeWrapper));
            }
        }
        public void SetBody(string body)
        {
                ...
                Body = body + DateTimeWrapper.Now.ToString();
        }
    }
