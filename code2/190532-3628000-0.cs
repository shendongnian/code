    public class MyDataClass
    {
        private Hashtable properties = new Hashtable();
        public string CompanyName
        {
            get { return GetValue<string>("CompanyName"); }
            set { SetValue<string>("CompanyName", value); }
        }
        public TResult GetValue<TResult>(string key)
        {
            return (TResult)(properties[key] ?? default(TResult));
        }
        public void SetValue<TValue>(string key, TValue value)
        {
            // Perform validation here...
            properties[key] = value;
        }
    }
