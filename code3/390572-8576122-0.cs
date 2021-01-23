    [DataContract]
    [KnownType(typeof(My3dPartyObjectString))]
    [KnownType(typeof(My3dPartyObjectInt64))]
    public abstract class My3dPartyObjectBase
    {
    // some common properties
    }
    [DataContract]
    public class My3dPartyObjectString : My3dPartyObjectBase
    {
    public Dictionary<3PAttributeKeysEnum, string> MyStringAttributes { get; set; }
    }
    [DataContract]
    public class My3dPartyObjectInt64 : My3dPartyObjectBase
    {
    public Dictionary<3PAttributeKeysEnum, long> MyStringAttributes { get; set; }
    }
