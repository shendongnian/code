    Module StringExtensions
        <Extension()>
        Public Function TextFollowing(txt As String, value As String) As String
            If Not String.IsNullOrEmpty(txt) AndAlso Not String.IsNullOrEmpty(value) Then
                Dim index As Integer = txt.IndexOf(value)
                If -1 < index Then
                    Dim start As Integer = index + value.Length
                    If start <= txt.Length Then
                        Return txt.Substring(start)
                    End If
                End If
            End If
            Return Nothing
        End Function
        <Extension()>
        Public Function TextPreceding(txt As String, value As String) As String
            If Not String.IsNullOrEmpty(txt) AndAlso Not String.IsNullOrEmpty(value) Then
                Dim index As Integer = txt.IndexOf(value)
                If -1 < index Then
                    Return txt.Substring(0, index)
                End If
            End If
            Return Nothing
        End Function
    End Module
