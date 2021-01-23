    Imports System.Runtime.Serialization
    Public Sub WriteToStream(sw As System.IO.Stream)
        Dim dataContractSerializer As New DataContractSerializer(GetType(MyDataSource))
        dataContractSerializer.WriteObject(sw, _MyDataSource)
    End Sub
    Public Sub ReadFromStream(sr As System.IO.Stream)
        Dim dataContractSerializer As New DataContractSerializer(GetType(MyDataSource))
        _MyDataSource = dataContractSerializer.ReadObject(sr)
    End Sub
