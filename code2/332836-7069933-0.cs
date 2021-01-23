    public class TestClass
    {
        public TestClass()
        {
            // defaults
            this.IdField = 1;
            this.IdProperty = 2;
        }
    
        public int IdField;
        public int IdProperty { get; set; }
    }
    
    // here is an object obj and you don't know which its underlying type
    object obj = new TestClass();
    var idProperty = obj.GetType().GetProperty("IdProperty");
    if (idProperty != null)
    {
        // retrieve it and then parse to int using int.TryParse()
        var intValue = idProperty.GetValue(obj, null);
    }
    
    var idField = obj.GetType().GetField("IdField");
    if (idField != null)
    {
        // retrieve it and then parse to int using int.TryParse()
        var intValue = idField.GetValue(obj);
    }
