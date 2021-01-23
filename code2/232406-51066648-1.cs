    public static void Main()
    {
        object myObject = new TestGeneric<string>("test"); // or from another source
    
        var type = myObject.GetType();
    
        if (IsSubclassOfRawGeneric(typeof(TestGeneric<>), type))
        {
            var dataProperty = type.GetProperty(nameof(TestGeneric<object>.Data));
            object data = dataProperty.GetValue(myObject);
        }
    }
