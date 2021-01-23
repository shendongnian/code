    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = 135 AndAlso DroppedDown Then 'WM_GETDLGCODE
            DroppedDown = False
        End If
        MyBase.WndProc(m)
    End Sub
