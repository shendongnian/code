    public class User
    {
        Dictionary<string, string> Values = new Dictionary<string, string>();
        public string this[string key]
            {
                get
                {
                    return Values[key];
                }
                set
                {
                    Values[key] = value;
                }
            }
    }
