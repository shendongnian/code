        Option Explicit
        Private objFactory As Object
    
        Public Sub RegisterFactory(Factory As Object)
            Set objFactory = Factory
        End Sub
