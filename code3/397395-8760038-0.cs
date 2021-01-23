    Interface IA
        Property NumberA() As Integer
    End Interface
    
    Interface IB
        Inherits IA
    
        Property NumberB() As Integer
    End Interface
    
    Class A
        Implements IA
    
        Public Property NumberA() As Integer Implements IA.NumberA
            Get
                Return m_NumberA
            End Get
            Set(ByVal value As Integer)
                m_NumberA = value
            End Set
        End Property
        Private m_NumberA As Integer
    End Class
    
    Class B
        Inherits A
        Implements IB
    
        Public Property NumberB() As Integer Implements IB.NumberB
            Get
                Return m_NumberB
            End Get
            Set(ByVal value As Integer)
                m_NumberB = value
            End Set
        End Property
        Private m_NumberB As Integer
    End Class
