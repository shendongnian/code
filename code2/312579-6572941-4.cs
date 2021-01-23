    Dim mCandidates As New HashSet(Of String)
    Sub ExpandFullNameOfSelection()
        Dim selection As EnvDTE.TextSelection = CType(DTE.ActiveDocument.Selection(), EnvDTE.TextSelection)
        ' Assume type is selected
        Dim className As String = selection.Text
        ' Find current context
        Dim currentFunction As CodeElement = FindCodeElement(selection.ActivePoint, DTE.ActiveDocument.ProjectItem.FileCodeModel.CodeElements)
        mCandidates.Clear()
        FindAllCandidates(currentFunction, className)
        Dim classType As CodeElement = DTE.Solution.Projects.Cast(Of Project) _
                                                            .Where(Function(x) x.CodeModel IsNot Nothing) _
                                                            .Select(Function(x) FindClassInCodeElements(x.CodeModel.CodeElements)) _
                                                            .FirstOrDefault(Function(x) x IsNot Nothing)
        If classType IsNot Nothing Then
            selection.Text = classType.FullName ' replace with full name
        End If
    End Function
