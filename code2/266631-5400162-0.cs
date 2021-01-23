    public class MyClass : IBase, IBaseSub<YourObject>
    {
        public YourObject Property1 { get; set; }
        MyObject IBase.Property1 { get; set; }
    }
