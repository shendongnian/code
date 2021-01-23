    Option Strict On : Option Explicit On
    
    Module Module1
        Sub Main()
            System.Console.WriteLine("Main")
            Dim g = C.A
        End Sub
    End Module
    Public Class C
        Shared Function Narg() As A
            Dim alpha As New A
            System.Console.WriteLine("Init C")
            Return alpha
        End Function
        Shared Property A As A = Narg()
    End Class
    Public Class A
        Shared Sub New()
            System.Console.WriteLine("Init A")
        End Sub
        Public Sub New()
            System.Console.WriteLine("A Constructor")
        End Sub
    End Class
