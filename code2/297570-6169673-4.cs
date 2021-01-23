    Public Class DerivedRichTextBox
        Inherits RichTextBox
    
        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    
            ' windows message constant for scrollwheel moving
            Const WM_SCROLLWHEEL As Integer = &H20A
    
            Dim scrollingAndPressingControl As Boolean = m.Msg = WM_SCROLLWHEEL AndAlso Control.ModifierKeys = Keys.Control
    
            'if scolling and pressing control then do nothing (don't let the base class know), 
            'otherwise send the info down to the base class as normal
            If (Not scrollingAndPressingControl) Then
    
                MyBase.WndProc(m)
    
            End If
    
    
        End Sub
    
    End Class
