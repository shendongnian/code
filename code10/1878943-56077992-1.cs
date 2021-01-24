    using Newtonsoft.Json;
    public class MyClass
    {
        [JsonConstructor]
        private MyClass() // for serializer
        {
        }
    
        public MyClass(string myProperty) // for myself
        {
            MyProperty = myProperty ?? throw new ArgumentNullException(nameof(myProperty));
        }
    
        [Required]
        public string MyProperty { get; private set; }
    }
