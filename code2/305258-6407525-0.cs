    [ProtoMember(1, DataFormat = DataFormat.Group)]
    public SomeType SomeChild { get; set; }
    ....
    [ProtoMember(4, DataFormat = DataFormat.Group)]
    public List<SomeOtherType> SomeChildren { get { return someChildren; } }
