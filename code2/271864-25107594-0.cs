    Public Class MyExtendedBrowserControl
    ' Based on WebBrowser
    Inherits System.Windows.Forms.WebBrowser
    
    ' Define constants from winuser.h
    Private Const WM_PARENTNOTIFY As Integer = &H210
    Private Const WM_DESTROY As Integer = 2
    
    'Define New event to fire
    Public Event WBWantsToClose()
    
    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case WM_PARENTNOTIFY
                If (Not DesignMode) Then
                    If (m.WParam = WM_DESTROY) Then
                        ' Tell whoever cares we are closing
                        RaiseEvent WBWantsToClose()
                    End If
                End If
                DefWndProc(m)
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub
    
    End Class
