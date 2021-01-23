    Public Class Foo 
       Public Sub Bar()
       End Sub
    End Class
    
    Public Class Test
       Public Sub Test()
          Dim o as Object
          o = New Foo()
          ' This will compile and work
          o.Bar()
          ' This will also compile but will throw an exception
          o.NonExistingMember()
       End Sub
    End Class
