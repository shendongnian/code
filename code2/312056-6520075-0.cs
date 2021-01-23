    public object Value { get;set;}
    [ProtoMember(1)]
    public int? ValueInt32 {
        get { return (Value is int) ? (int)Value : (int?)null; }
        set { Value = value; }
    }
    [ProtoMember(2)]
    public string ValueString {
        get { return (Value is string) ? (string)Value : null; }
        set { Value = value; }
    }
    // etc
