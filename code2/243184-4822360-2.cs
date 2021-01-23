    Public Class Form1
        Private d As New Dings("dings")
    End Class
    Public Class Foo
        Public Sub New(ByVal aName As String)
            MsgBox("new Foo """ & aName & """")
        End Sub
    End Class
    Public Class Dings
        Public Property Name As String
        Public Property MyFoo As Foo
    
        Public Sub New(ByVal aName As String)
            Name = aName
            MyFoo = New Foo(aName)
        End Sub
    End Class
