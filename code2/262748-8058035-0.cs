    Dim MustUpdateDB As Boolean
    
        Private Sub DebuggerEvents_OnEnterRunMode(ByVal Reason As EnvDTE.dbgEventReason) Handles DebuggerEvents.OnEnterRunMode
            If (MustUpdateDB) Then
                MsgBox("Start debug operation", MsgBoxStyle.OkOnly, "TITLE")
                REM DO WHATEVER COMMAND HERE
                REM  System.Diagnostics.Process.Start("C:\listfiles.bat")
                MustUpdateDB = False
            End If
    
    
        End Sub
    
        Private Sub BuildEvents_OnBuildDone(ByVal Scope As EnvDTE.vsBuildScope, ByVal Action As EnvDTE.vsBuildAction) Handles BuildEvents.OnBuildDone
            MsgBox("Build Done", MsgBoxStyle.OkOnly, "Title")
            MustUpdateDB = True
        End Sub
