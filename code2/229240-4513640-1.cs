    Public Shared Sub Main(ByVal args() As String)
        Dim me As New Person
        me.FirstName = "Adam"
        me.LastName = "Maras"
        AssignByValue(me)
        Console.WriteLine(me.LastName) ' Writes "Maras"
        AssignByReference(me)
        Console.WriteLine(me.LastName) ' Writes "Doe"
    End Sub
    Public Shared Sub AssignByValue(ByVal someone As Person)
        Dim new As New Person
        new.FirstName = "John"
        new.LastName = "Doe"
        someone = new
    End Sub
    Public Shared Sub AssignByReference(ByRef someone As Person)
        Dim new As New Person
        new.FirstName = "John"
        new.LastName = "Doe"
        someone = new
    End Sub
