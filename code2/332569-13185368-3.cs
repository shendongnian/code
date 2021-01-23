    Sub TemporaryMacro()
        DTE.ActiveDocument.Selection.StartOfLine(VsStartOfLineOptions.VsStartOfLineOptionsFirstText)
        DTE.ActiveDocument.Selection.Delete(7)
        DTE.ActiveDocument.Selection.Text = "public"
        DTE.ActiveDocument.Selection.CharRight()
        DTE.ExecuteCommand("Edit.Find")
        DTE.Find.FindWhat = " "
        DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocument
        DTE.Find.MatchCase = False
        DTE.Find.MatchWholeWord = False
        DTE.Find.Backwards = False
        DTE.Find.MatchInHiddenText = False
        DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxLiteral
        DTE.Find.Action = vsFindAction.vsFindActionFind
        If (DTE.Find.Execute() = vsFindResult.vsFindResultNotFound) Then
            Throw New System.Exception("vsFindResultNotFound")
        End If
        DTE.ActiveDocument.Selection.CharRight()
        DTE.ActiveDocument.Selection.WordRight(True)
        DTE.ActiveDocument.Selection.CharLeft(True)
        DTE.ActiveDocument.Selection.Copy()
        DTE.ActiveDocument.Selection.CharLeft()
        DTE.ActiveDocument.Selection.CharRight(True)
        DTE.ActiveDocument.Selection.ChangeCase(VsCaseOptions.VsCaseOptionsUppercase)
        DTE.ActiveDocument.Selection.EndOfLine()
        DTE.ActiveDocument.Selection.StartOfLine(VsStartOfLineOptions.VsStartOfLineOptionsFirstText)
        DTE.ExecuteCommand("Edit.Find")
        DTE.Find.FindWhat = " = "
        DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocument
        DTE.Find.MatchCase = False
        DTE.Find.MatchWholeWord = False
        DTE.Find.Backwards = False
        DTE.Find.MatchInHiddenText = False
        DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxLiteral
        DTE.Find.Action = vsFindAction.vsFindActionFind
        If (DTE.Find.Execute() = vsFindResult.vsFindResultNotFound) Then
            Throw New System.Exception("vsFindResultNotFound")
        End If
        DTE.ActiveDocument.Selection.CharLeft()
        DTE.ActiveDocument.Selection.EndOfLine(True)
        DTE.ActiveDocument.Selection.Delete()
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "{"
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "get { return "
        DTE.ActiveDocument.Selection.Paste()
        DTE.ActiveDocument.Selection.Text = "; }"
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "set"
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "{"
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "if("
        DTE.ActiveDocument.Selection.Paste()
        DTE.ActiveDocument.Selection.Text = " != value)"
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "{"
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Paste()
        DTE.ActiveDocument.Selection.Text = " = value;"
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "OnPropertyChanged("""
        DTE.ActiveDocument.Selection.Paste()
        DTE.ActiveDocument.Selection.Text = """);"
        DTE.ActiveDocument.Selection.StartOfLine(VsStartOfLineOptions.VsStartOfLineOptionsFirstText)
        DTE.ExecuteCommand("Edit.Find")
        DTE.Find.FindWhat = """"
        DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocument
        DTE.Find.MatchCase = False
        DTE.Find.MatchWholeWord = False
        DTE.Find.Backwards = False
        DTE.Find.MatchInHiddenText = False
        DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxLiteral
        DTE.Find.Action = vsFindAction.vsFindActionFind
        If (DTE.Find.Execute() = vsFindResult.vsFindResultNotFound) Then
            Throw New System.Exception("vsFindResultNotFound")
        End If
        DTE.ActiveDocument.Selection.CharRight()
        DTE.ActiveDocument.Selection.CharRight(True)
        DTE.ActiveDocument.Selection.ChangeCase(VsCaseOptions.VsCaseOptionsUppercase)
        DTE.ActiveDocument.Selection.Collapse()
        DTE.ActiveDocument.Selection.EndOfLine()
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "}"
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "}"
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "}"
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.LineDown()
        DTE.ActiveDocument.Selection.EndOfLine()
    End Sub
