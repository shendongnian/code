    Public Class Dings
        Public Property Name As String
        Private fooBacking As Foo
    
        Public Property MyFoo As Foo
            Get
                Return fooBacking
            End Get
            Set(ByVal value As Foo)
                fooBacking = value
            End Set
        End Property
    
        Public Sub New(ByVal aName As String)
            _Name = aName
            MyFoo = New Foo(_Name)
        End Sub
    End Class
