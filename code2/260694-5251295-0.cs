    public static T GetValue<T>(this Enum e) where T:class
    {
        FieldInfo fi = e.GetType().GetField(e.ToString());
        var valueAttribute = fi.GetCustomAttributes(typeof (ValueAttribute), 
            false).FirstOrDefault() as ValueAttribute;
        if (valueAttribute != null) return valueAttribute.Value as T;
        return null;
    }
    class PersonValueAttribute : ValueAttribute
    {
        public PersonValueAttribute(string firstName, string lastName)
        {
            base.Value = new Person {FirstName = firstName, LastName = lastName};
        }
    }
    
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public static implicit operator Person(Enum e)
        {
            return e.GetValue<Person>();
        }
    }
    
    enum PeopleList
    {
        [PersonValue("Steve", "Jobs")]
        Steve
    }
