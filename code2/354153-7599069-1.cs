    class MyClass
    {
        public int Field;
        public string Property { get; set; }
    }
    var fieldName = GetMemberName((MyClass c) => c.Field);
    var propertyName = GetMemberName((MyClass c) => c.Property);
    // fieldName has string value of `Field`
    // propertyName has string value of `Property`
