    Public Enum AnimalTypes
        Animal = 1
        Pig = 2
        Human = 3
    End Enum
    Public Class AnimalBase
        Public Overridable ReadOnly Property AnimalType() As AnimalTypes
            Get
                Return AnimalTypes.Animal
            End Get
        End Property
        Public Sub Move(ByVal X As Integer, ByVal Y As Integer)
            ' . . . You movement code
        End Sub
    End Class
