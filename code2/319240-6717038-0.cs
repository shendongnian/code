    Imports System.Runtime.InteropServices
    Public Class NativeTabControl
        Inherits NativeWindow
        Private Const TCM_FIRST As Int32 = &H1300
        Private Const TCM_ADJUSTRECT As UInt32 = (TCM_FIRST + 40)
    Private baseCtrl As TabControl
    Public Sub New(ByVal ctrl As TabControl)
        Me.baseCtrl = ctrl
        AddHandler ctrl.HandleDestroyed, AddressOf OnHandleDestroyed
        Me.AssignHandle(ctrl.Handle)
    End Sub
    Private Sub OnHandleDestroyed(ByVal sender As Object, ByVal e As EventArgs)
        ' Window was destroyed, release hook.
        RemoveHandler baseCtrl.HandleDestroyed, AddressOf OnHandleDestroyed
        Me.ReleaseHandle()
    End Sub
    Protected Overrides Sub WndProc(ByRef m As Message)
        If (m.Msg = TCM_ADJUSTRECT) Then
            Dim rc As RECT = DirectCast(m.GetLParam(GetType(RECT)), RECT)
            'Adjust these values to suit, dependant upon Appearance
            rc.Left -= 3
            rc.Right += 1
            rc.Top -= 1
            rc.Bottom += 1
            Marshal.StructureToPtr(rc, m.LParam, True)
        End If
        MyBase.WndProc(m)
    End Sub
    Private Structure RECT
        Public Left, Top, Right, Bottom As Int32
    End Structure
    End Class
