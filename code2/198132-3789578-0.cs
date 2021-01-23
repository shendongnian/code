    Public Class MyButton
        Inherits Button
    
        Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
            '' Do your stuff here
            ''....
    
            '' Other event handlers will run now:
            MyBase.OnClick(e)
        End Sub
    End Class
