    <DllImport("user32.dll")> _
    Private Shared Function ShowScrollBar(hWnd As IntPtr, wBar As Integer, bShow As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    Private Enum ScrollBarDirection
        SB_HORZ = 0
        SB_VERT = 1
        SB_CTL = 2
        SB_BOTH = 3
    End Enum
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If Me.Visible Then
            ShowScrollBar(Me.Handle, CInt(ScrollBarDirection.SB_BOTH), False)
            MyBase.WndProc(m)
        End If
    End Sub
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.AutoScroll = True
    End Sub
