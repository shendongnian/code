    public class MyClass
    {
        public object Item { get; set; }
        [System.Runtime.CompilerServices.IndexerName("MyItem")]
        public object this[string index] { get { return null; } set { } }
    }
