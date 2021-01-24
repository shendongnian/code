        Public Shared Function GetBinary(ByVal image As Image, ByVal format As ImageFormat) As Byte()
        Using ms As New System.IO.MemoryStream
            If (format Is Nothing) Then
                format = image.RawFormat 
            End If
            image.Save(ms, format)
            Return ms.ToArray()
        End Using
        End Function here
