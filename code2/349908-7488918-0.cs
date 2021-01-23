    public Type DeviceType { get; set; }
    [DataMember(Name="DeviceType")]
    private string DeviceTypeName {
        get { return DeviceType == null ? null : DeviceType.AssemblyQualifiedName; }
        set { DeviceType = value == null ? null : Type.GetType(value); }
    }
