    Imports System
    
    Public Class Test
    
        Public Shared Sub Main()
            Dim o As Object = 5
            
            If TypeOf o Is IFormattable Then
                Console.WriteLine("Yes")
            End If
        End Sub    
    
    End Class
