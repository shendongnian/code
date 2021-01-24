vb
<Serializable>
Public Class InitializePagedPull
    <XmlElement>
    Public Property TokenInfo As TokenInfo
End Class
Class TokenInfo
    <XmlAttribute>
    Public Property PageToken As String
    <XmlAttribute>
    Public Property TotalRecords As Integer
    <XmlAttribute>
    Public Property PageSize As Integer
    <XmlAttribute>
    Public Property TotalPages As Integer
End Class
Then assuming your xml is an XElement,
vb
Dim xml = <InitializePagedPull ShowCode="AR13dfD">
              <TokenInfo PageToken="293845657-32-47" TotalRecords="1" PageSize="20" TotalPages="1"/>
          </InitializePagedPull>
Dim serializer As New XmlSerializer(GetType(InitializePagedPull))
Dim pull = DirectCast(serializer.Deserialize(xml.CreateReader()), InitializePagedPull)
Dim pageToken = pull.TokenInfo.PageToken
