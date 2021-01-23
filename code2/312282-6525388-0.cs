    public class MyResources
    {
        public const string BaseString = "there";
    }
    [FooAttribute(Value = MyReources.BaseString + " - Bar"))]
    public int FooBar { get; set; }
