    Public Shared Function FindShort(ByVal sentence As String) As Integer
        If Not String.IsNullOrEmpty(sentence) Then
            Return Regex.Split(sentence, "\s+").OrderBy(Function(x1) x1.Length).ToList().First().Length
        End If
    
        Return -1
    End Function
