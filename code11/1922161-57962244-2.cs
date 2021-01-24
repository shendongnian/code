    Public Class Product
        Public Property Model As String
        Public Property Opt As String
        Public Property Description As String
        Private strPrice As String
        Public Property Price As Double
        'Add a parameterized constructor to your class to make coding easier
        Public Sub New(Mdl As String, O As String, Desc As String, P As String)
            Model = Mdl
            Opt = O
            Description = Desc
            Dim ParsedDouble As Double
            Double.TryParse(P, ParsedDouble)
            Price = ParsedDouble
        End Sub
    End Class
