     Public Class A
         // Do Stuff, methods, members, etc.
         Public var As Object
         Public Sub New()
             member = New Object
         End Sub
     End Class
     // yes it's empty
     Public Class B : Inherits A
     End Class
     // yes it's empty
     Public Class C : Inherits A
         Public Sub New()
             MyBase.New()
             member.SomeMethod()
         End Sub
     End Class
