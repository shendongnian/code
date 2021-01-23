    Public Interface ITest
        ReadOnly Property Testable As Boolean
    End Interface
    
    Public Class Test
        Implements ITest
    
        ' Note: Here I am NOT implementing the interface. '
        Private _testable As Boolean
        Public Property Testable() As Boolean
            Get
                Return _testable
            End Get
            Private Set(ByVal value As Boolean)
                _testable = value
            End Set
        End Property
    
        ' This is where I define a read-only property to satisfy the interface '
        ' (from the perspective of the VB compiler). '
        ' Notice this is a lot like explicit interface implementation in C#. '
        Private ReadOnly Property TestableExplicit() As Boolean Implements ITest.Testable
            Get
                Return Testable
            End Get
        End Property
    End Class
