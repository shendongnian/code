    Public Function TryParse(wIndex As Integer, s As String) As Boolean
        Dim oObject As Object
        oObject = Me.Item(wIndex)
        Select Case oObject.GetType.Name.ToLower
            Case "int32", "system.int32"
                Dim wTestInt As Integer
                Return Int32.TryParse(s, wTestInt)
                ' Etc...
        End Select
    End Function
