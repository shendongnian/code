    Public Class MyException
        Inherits Exception
        Public Property SomeList As New List(Of String) From {"hello", "world"}
    End Class
  
    <TestFixture()>
    Public Class TestClass1
        Public Shared Sub DoSomething()
            Throw New MyException()
        End Sub
        <Test()>
        Public Sub TestExample()
            Assert.That(Sub() DoSomething(), Throws.TypeOf(Of MyException)().With.Property("SomeList").Count.EqualTo(3))
        End Sub
    End Class
