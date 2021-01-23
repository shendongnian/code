    ' Serialization constructor
    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        ' This only needs to be called if this class inherits from a serializable class
        'Call MyBase.New(info, context)
        Call DeserializeObject(Me, GetType(ActionBase), info)
    End Sub
    ' Ensure that the other class members that are not part of the NameObjectCollectionBase are serialized
    Public Overridable Sub GetObjectData(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext) Implements ISerializable.GetObjectData
        ' This only needs to be called if this class inherits from a serializable class
        'MyBase.GetObjectData(info, context)
        Call SerializeObject(Me, GetType(ActionBase), info)
    End Sub
