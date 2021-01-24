    Public Class Product
        Public Property Model As String
        Public Property Opt As String
        Public Property Description As String
        Public Property Price As String
        'Add a parameterized constructor to your class to make coding easier
        Public Sub New(Mdl As String, O As String, Desc As String, P As String)
            Model = Mdl
            Opt = O
            Description = Desc
            Price = P
        End Sub
    End Class
    Dim Products As ObservableCollection(Of Product)
    Private Sub LoadBound(ByVal fName As String)
        'Build a List(Of Product) from the text file
        Dim lstProducts As New List(Of Product)
        Dim lines = File.ReadAllLines(fName)
        For Each line In lines
            Dim Props = line.Split(CChar(vbTab))
            Dim p As New Product(Props(0), Props(1), Props(2), Props(3))
            lstProducts.Add(p)
        Next
        'The constructor of an ObservableCollection can take a List(Of T)
        Products = New ObservableCollection(Of Product)(lstProducts)
    End Sub
