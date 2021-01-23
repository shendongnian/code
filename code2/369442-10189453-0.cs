    Sub RemoveBreakPoint()
        Dim debugger As EnvDTE.Debugger = DTE.Debugger
        Dim children As EnvDTE.Breakpoints
        Dim sel As Integer = DTE.ActiveDocument.Selection.ActivePoint.Line
        For Each bp As EnvDTE.Breakpoint In debugger.Breakpoints
            If bp.File <> DTE.ActiveDocument.FullName Then
                Continue For
            End If
            For Each bpc As EnvDTE.Breakpoint In bp.Children
                If bpc.FileLine = sel Then
                    bp.Delete()
                    Exit For
                End If
            Next
        Next
    End Sub
