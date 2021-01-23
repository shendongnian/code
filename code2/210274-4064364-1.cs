    public class BusinessManager<T> where T : Business, new()
        {
            private T _business;
    
            public string ShowBusinessName()
            {
                string businessName;
                _business = new T();
                return _business.GetBusinessName();
            }
        }
