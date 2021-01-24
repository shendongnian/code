    Public Class MyButton
        Inherits Button
        Public Property Form As String
        Protected Overrides Sub OnClick(e As EventArgs)
            If (Not String.IsNullOrEmpty(Form)) Then
                Dim fp = My.Forms.GetType().GetProperty(Form)
                If (fp IsNot Nothing) Then
                    Dim f = fp.GetValue(My.Forms)
                    DirectCast(f, Form).ShowDialog()
                End If
            End If
            MyBase.OnClick(e)
        End Sub
    End Class
