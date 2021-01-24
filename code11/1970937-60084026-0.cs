    void Main()
    {
        Test(typeof(Foo<string>), "Data");
        Test(typeof(Foo<string>), "Bar");
    }
    
    public void Test(Type type, string propertyName)
    {
        if (type.IsGenericType)
            type = type.GetGenericTypeDefinition();
            
        PropertyInfo pi = type.GetProperty(propertyName);
        if (pi.PropertyType.IsGenericTypeParameter)
            Console.WriteLine("<generic> " + pi);
        else
            Console.WriteLine("<not generic> " + pi);
    }
    
    public class Foo<T>
    {
        public T Data { get; set; }
        public string Bar { get; set; }
    }
