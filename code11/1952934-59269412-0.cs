    class MyClass
    {
       [JsonProperty]
       private MyChildClass MyProperty { set => MyNewProperty = YourConversionMethod(value); }
    
       public MyNewChildClass MyNewProperty { get; set; }
    }
