vb.net
    Public MustInherit Class isSerializable(Of T)
        Private Shared myType As Type = GetType(T)
        Private Shared validTypes As New List(Of Type) From {GetType(Short), GetType(Integer), GetType(Single)}
        'Static constructor which is called once for every derived class
        Shared Sub New()
            Dim info() As FieldInfo = myType.GetFields()
            For Each field In info
                Dim fieldType = field.FieldType()
                If Not validTypes.Contains(fieldType) Then
                    Throw New Exception(myType.Name & " has invalid types.")
                End If
            Next
        End Sub
    End Class
