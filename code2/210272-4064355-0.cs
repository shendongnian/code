    public class BusinessManager<T> where T : Business, new()
    ...
    T _business = new T();
    string businessName = _business.GetBusinessName();
    return businessName;
