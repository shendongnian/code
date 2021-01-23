      Public Function Serialize(Of YourXMLClass)(ByVal obj As YourXMLClass,
                                                          Optional ByVal omitXMLDeclaration As Boolean = True,
                                                          Optional ByVal omitXMLNamespace As Boolean = True) As String
    
            Dim serializer As New XmlSerializer(obj.GetType)
            Using memStream As New MemoryStream()
                Dim settings As New XmlWriterSettings() With {
                        .Encoding = Encoding.UTF8,
                        .Indent = True,
                        .OmitXmlDeclaration = omitXMLDeclaration}
    
                Using writer As XmlWriter = XmlWriter.Create(memStream, settings)
                    Dim xns As New XmlSerializerNamespaces
                    If (omitXMLNamespace) Then xns.Add("", "")
                    serializer.Serialize(writer, obj, xns)
                End Using
    
                Return Encoding.UTF8.GetString(memStream.ToArray())
            End Using
        End Function
    
     Public Function Deserialize(Of YourXMLClass)(ByVal obj As YourXMLClass, ByVal xml As String) As YourXMLClass
            Dim result As YourXMLClass
            Dim serializer As New XmlSerializer(GetType(YourXMLClass))
    
            Using memStream As New MemoryStream()
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(xml.ToArray)
                memStream.Write(bytes, 0, bytes.Count)
                memStream.Seek(0, SeekOrigin.Begin)
    
                Using reader As XmlReader = XmlReader.Create(memStream)
                    result = DirectCast(serializer.Deserialize(reader), YourXMLClass)
                End Using
    
            End Using
            Return result
        End Function
