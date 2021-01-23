Public Class FormEx
    Inherits Form
    Private Declare Function MoveWindow Lib "User32.dll" (ByVal hWnd As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Repaint As Boolean) As Boolean
    Public Overrides Property MaximumSize As System.Drawing.Size
        Get
            Return MyBase.MaximumSize
        End Get
        Set(value As System.Drawing.Size)
            MyBase.MaximumSize = value
            If Me.DesignMode Then
                MoveWindow(Me.Handle, Me.Left, Me.Top, value.Width, value.Height, True)
            End If
        End Set
    End Property
End Class
