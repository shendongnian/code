    Public Const FilterDigits As String = "0123456789"
    Public Const FilterLetters As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
    ''' <summary>
    ''' Strips away any characters not defined in validChars and returns the result.
    ''' </summary>
    Public Shared Function FilterTo(ByVal text As String, ByVal validChars As String) As String
        Dim Result As New StringBuilder
        For i As Integer = 1 To text.Length
            Dim CurrentChar As Char = CChar(Mid(text, i, 1))
            If validChars.Contains(CurrentChar) Then
                Result.Append(CurrentChar)
            End If
        Next
        Return Result.ToString
    End Function
