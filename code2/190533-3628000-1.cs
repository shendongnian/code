    // Example attribute class for MaxStringLength
    public class MaxStringLengthAttribute : Attribute
    {
        public int MaxLength { get; set; }
        public MaxStringLengthAttribute(int length) { this.MaxLength = length; }
    }
    // Class using the dictionary store and shared validation routine.
    public class MyDataClass
    {
        private Hashtable properties = new Hashtable();
        public string CompanyName
        {
            get { return GetValue<string>("CompanyName"); }
            [MaxStringLength(50)]
            set { SetValue<string>("CompanyName", value); }
        }
        public TResult GetValue<TResult>(string key)
        {
            return (TResult)(properties[key] ?? default(TResult));
        }
        public void SetValue<TValue>(string key, TValue value)
        {
            // Example retrieving attribute:
            var attributes = new StackTrace()
                                 .GetFrame(1)
                                 .GetMethod()
                                 .GetCustomAttributes(typeof(MaxStringLengthAttribute), true);
            // With the attribute in hand, perform validation here...
            properties[key] = value;
        }
    }
