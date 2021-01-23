    // file 1
    partial class GeneratedClass
    {
        public int Foo { get; set; }
        public string Bar { get; set; }
    }
    // file 2
    [ProtoPartialMember(1, "Foo")]
    [ProtoPartialIgnore("Bar")]
    partial class GeneratedClass {}
