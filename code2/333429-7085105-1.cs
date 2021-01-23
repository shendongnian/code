    Public NotInheritable Class ObjectSetExtensions
        Private Sub New()
        End Sub
        <System.Runtime.CompilerServices.Extension> _
        Public Shared Sub AddObjects(Of T)(objectSet As ObjectSet(Of T), objects As IEnumerable(Of T))
            For Each item As var In objects
                objectSet.AddObject(item)
            Next
        End Sub
    End Class
