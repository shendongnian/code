    Class B : Inherits TestLibrary.A
        Public Overrides ReadOnly Property X As Integer
            Get
                Return MyBase.X
            End Get
        End Property
    End Class
