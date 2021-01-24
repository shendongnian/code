    Public Class MyButton
        Inherits Button
        Public Property Form As String
        Protected Overrides Sub OnClick(e As EventArgs)
            Dim fp = My.Forms.GetType().GetProperty(Form)
            If(fp IsNot Nothing)
                dim f = fp.GetValue(My.Forms)
                DirectCast(f, Form).ShowDialog()
            End If
            MyBase.OnClick(e)
        End Sub
    End Class
