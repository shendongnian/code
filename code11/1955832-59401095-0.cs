    static void Main(string[] args)
    {
        var list1 = new List<Contact>();
        var list2 = new List<Contact>();
        var list3 = list1.Except(list2, new PropertyComparer<Contact>("ContactId"));
        foreach (var item in list3) 
            Console.WriteLine(item.ContactId.ToString());
        Console.ReadLine();
    }
    public class Contact
    {
        public Guid ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class PropertyComparer<T> : IEqualityComparer<T>
    {
        private PropertyInfo _PropertyInfo;
        public PropertyComparer(string propertyName)
        {
            _PropertyInfo = typeof(T).GetProperty(propertyName,
                BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public);
            if (_PropertyInfo == null)
            {
                throw new ArgumentException(
                    string.Format("{0} is not a property of type {1}.", propertyName, typeof(T)));
            }
        }
        public int GetHashCode(T obj)
        {
            object propertyValue = _PropertyInfo.GetValue(obj, null);
            if (obj == null) return 0;
            return propertyValue.GetHashCode();
        }
        public bool Equals(T x, T y)
        {
            object xValue = _PropertyInfo.GetValue(x, null);
            object yValue = _PropertyInfo.GetValue(y, null);
            if (xValue == null)
            {
                return yValue == null;
            }
            return xValue.Equals(yValue);
        }
    }
