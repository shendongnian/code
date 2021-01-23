     Module Module1
    
        Sub Main()
            Dim CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
            If CommandLineArgs.Count = 1 Then
                Try
                    Dim path As String = FromBase64(CommandLineArgs(0))
                    Diagnostics.Process.Start(path)
                Catch
                End Try
                End
            End If
        End Sub
    
        Function FromBase64(ByVal base64 As String) As String
            Dim b As Byte() = Convert.FromBase64String(base64)
            Return System.Text.Encoding.UTF8.GetString(b)
        End Function
    
    End Module
