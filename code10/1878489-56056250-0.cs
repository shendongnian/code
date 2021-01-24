    Private Sub GetProjectReferences()
        Dim lines = New List(Of String)
        Dim path = "..\..\TestApp.vbproj"
        For Each line In File.ReadAllLines(path)
            If line.Contains("<ProjectReference") Then
                Dim projNameWithExtension = line.Substring(line.LastIndexOf("\") + 1)
                Dim projName = projNameWithExtension.Substring(0, projNameWithExtension.IndexOf(".vbproj"))
                lines.Add(projName)
            End If
        Next
    End Sub
