    Public Class Foo
        Public A As String = "A"
        Public Sub Bar(Baz As String)
             A = A & Baz
        End Sub
    End Class
    Dim x As New Foo()
    x.A = "x"
    Dim y As New Foo()
    y.A = "y"
  
