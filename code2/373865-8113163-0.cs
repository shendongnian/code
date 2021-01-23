    ''' <summary>
    ''' does something
    ''' </summary>
    ''' <param name="Test">a string</param>
    ''' <param name="fromDate">Optional date</param>
    ''' <remarks></remarks>
    Public Sub ExampleSub(ByVal Test As String, _
                          Optional ByVal fromDate As System.Nullable(Of DateTime) = Nothing)
        'A Great sub!
        If fromDate Is Nothing Then
            'code here for no fromDate
        End If
    End Sub
