    <Extension>
    Public Function ContainsDuplicates(Of T)(ByVal enumerable As IEnumerable(Of T)) As Boolean
        Dim knownKeys As New HashSet(Of T)
        Return enumerable.Any(Function(item) Not knownKeys.Add(item))
    End Function
