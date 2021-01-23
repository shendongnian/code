    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class Foo {...} // all public fields and properties are serialized,
                           // similar to XmlSerializer
    [ProtoContract(ImplicitFields = ImplicitFields.AllFields)]
    public class Bar {...} // all fields (not properties; public or private)
                           // are serialized, similar to BinaryFormatter
