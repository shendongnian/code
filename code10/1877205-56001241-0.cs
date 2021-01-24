    Public Shared table As System.Collections.Hashtable
    Public Shared Function current(ByVal key As String, ByVal value As Decimal) As Decimal
        If table Is Nothing Then
            table = New System.Collections.Hashtable()
        End If
        If table.ContainsKey(key) Then Return 0D
        table.Add(key, value)
        Return value
    End Function
