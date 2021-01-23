    Private Sub FindAllCandidates(ByVal elem As Object, ByVal className As String)
        If TypeOf elem Is CodeFunction Then
            FindAllCandidates(CType(elem, CodeFunction).Parent, className)
        ElseIf TypeOf elem Is CodeClass Then
            mCandidates.Add(CType(elem, CodeClass).FullName & "." & className)
            FindAllCandidates(CType(elem, CodeClass).Parent, className)
        ElseIf TypeOf elem Is CodeStruct Then
            mCandidates.Add(CType(elem, CodeStruct).FullName & "." & className)
            FindAllCandidates(CType(elem, CodeStruct).Parent, className)
        ElseIf TypeOf elem Is CodeNamespace Then
            mCandidates.Add(CType(elem, CodeNamespace).FullName & "." & className)
            For Each ns As String In CType(elem, CodeNamespace).Members.OfType(Of CodeImport) _
                                                                       .Select(Function(x) x.Namespace)
                mCandidates.Add(ns & "." & className)
            Next
            FindAllCandidates(CType(elem, CodeNamespace).Parent, className)
        ElseIf TypeOf elem Is FileCodeModel Then
            For Each ns As String In CType(elem, FileCodeModel).CodeElements.OfType(Of CodeImport) _
                                                                            .Select(Function(x) x.Namespace)
                mCandidates.Add(ns & "." & className)
            Next
        End If
    End Sub
