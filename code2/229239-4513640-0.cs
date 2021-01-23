    Public Class Person
        Public Property FirstName As String
        Public Property LastName As String
    End Class
    Public Shared Sub ModifyPerson(ByVal someone As Person)
        ' Passed by value          ^^^^^
        someone.LastName = "Doe"
    End Sub
    Public Shared Sub Main(ByVal args() As String)
        Dim me As New Person
        me.FirstName = "Adam"
        me.LastName = "Maras"
        ModifyPerson(me)
        Console.WriteLine(me.LastName) ' Writes "Doe"
    End Sub
