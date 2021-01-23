    Imports System
    Imports System.Windows.Forms
    
    Public Class TablessControl
               Inherits System.Windows.Forms.TabControl
        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            ' Hide tabs by trapping the TCM_ADJUSTRECT message
            If (m.Msg = Convert.ToInt32("0x1328", 16) And Not DesignMode) Then
                m.Result = CType(1, IntPtr)
            Else
                MyBase.WndProc(m)
            End If
        End Sub
    End Class
