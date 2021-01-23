    Sub addBreakpointWithCondition()
        Dim cond As String = InputBox("Enter the condition")
        DTE.Debugger.Breakpoints.Add(File:=DTE.ActiveDocument.FullName,
            Line:=DTE.ActiveDocument.Selection.CurrentLine, Condition:=cond)
    End Sub
