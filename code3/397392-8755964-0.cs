    Public Class A
    
        Public Property NumberA As Integer
    
    End Class
    
    Public Class B
        Inherits A
        Implements I
    
        Public Shadows Property NumberA As Integer Implements I.NumberA
            Get
                Return MyBase.NumberA
            End Get
            Set(ByVal value As Integer)
                MyBase.NumberA = value
            End Set
        End Property
    
        Public Property NumberB As Integer Implements I.NumberB
    
    End Class
    
    Interface I
        Property NumberA As Integer
        Property NumberB As Integer
    End Interface
