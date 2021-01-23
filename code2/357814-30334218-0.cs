    Public Shared Function SerializeObj(obj As Object) As String
        Dim xs As New System.Xml.Serialization.XmlSerializer(obj.GetType)
        Dim w As New IO.StringWriter
        xs.Serialize(w, obj)
        Return w.ToString
    End Function
