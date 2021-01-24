    Public Class Foo
        Public A As String
        Public Sub Bar(Baz As String)
             A = A & Baz
        End Sub
    End Class
    Dim x As New Foo With {.A = "x"}
    Dim y As New Foo With {.A = "y"}
  
