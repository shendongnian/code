    ''' <summary>
    ''' This method clones all of the items and serializable properties of the current collection by 
    ''' serializing the current object to memory, then deserializing it as a new object. This will 
    ''' ensure that all references are cleaned up.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateSerializedCopy(Of T)(ByVal oRecordToCopy As T) As T
        ' Exceptions are handled by the caller
        If oRecordToCopy Is Nothing Then
            Return Nothing
        End If
        If Not oRecordToCopy.GetType.IsSerializable Then
            Throw New ArgumentException(oRecordToCopy.GetType.ToString & " is not serializable")
        End If
        Dim oFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Using oStream As IO.MemoryStream = New IO.MemoryStream
            oFormatter.Serialize(oStream, oRecordToCopy)
            oStream.Position = 0
            Return DirectCast(oFormatter.Deserialize(oStream), T)
        End Using
    End Function
