    Public Class inventory
        Public Property id As Integer
        Public Property name As String
        'I added a custom constructor to make filling a list easier for me
        Public Sub New(i As Integer, n As String)
            id = i
            name = n
        End Sub
        'add back default constructor
        Public Sub New()
        End Sub
    End Class
    Private orders As New List(Of inventory) From {New inventory(1, "Apples"), New inventory(2, "Oranges"), New inventory(3, "Pears")}
    Private Sub OPCode()
        Dim rrr As String = "name" 'Console.ReadLine() as if user typed in name
        For Each i In orders
            Console.WriteLine(GetPropertyValue(i, rrr))
        Next
    End Sub
    Private Function GetPropertyValue(src As Object, PropName As String) As Object
        Return src.GetType().GetProperty(PropName).GetValue(src, Nothing)
    End Function
