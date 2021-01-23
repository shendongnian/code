    Public Class Pig
        Inherits AnimalBase
        Public Overrides ReadOnly Property AnimalType() As AnimalTypes
            Get
                Return AnimalTypes.Pig
            End Get
        End Property
        'A property spcific to the pig class:
        Public ReadOnly Property PigOnEquality() As String
            Get
                Return "Some pigs are more equal!"
            End Get
        End Property
    End Class
    Public Class Human
        Inherits AnimalBase
        Public Overrides ReadOnly Property AnimalType() As AnimalTypes
            Get
                Return AnimalTypes.Human
            End Get
        End Property
        'A property specific to the Human class:
        Public ReadOnly Property Shotgun() As String
            Get
                Return "Boom!"
            End Get
        End Property
    End Class
