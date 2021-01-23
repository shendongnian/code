    For Each p As String In HL7FilePaths
                If p <> newMergedFile Then
                    Dim sr As StreamReader = New StreamReader(p)
                    objWriter.Write(sr.ReadToEnd)
                    sr.Close()
                    sr.Dispose()
                End If
    Next
