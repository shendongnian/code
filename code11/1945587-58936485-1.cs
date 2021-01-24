    Private Sub ReleaseComObject(ByVal o As Object)
        Try
            If Not IsNothing(o) Then
                While System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0
                    'Wait for COM object to be released.'
                End While
            End If
            o = Nothing
        Catch exc As System.Runtime.InteropServices.COMException
            LogError(exc) ' Suppress errors thrown here '
        End Try
    End Sub
