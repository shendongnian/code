    Public Module Utilities
        <Extension>
        Public Function ContainsDuplicates(Of T)(ByVal enumerable As IEnumerable(Of T)) As Boolean
            Dim knownKeys As New HashSet(Of T)
            For Each item In enumerable
                If knownKeys.Contains(item) Then Return True
                knownKeys.Add(item)
            Next
            Return False
        End Function
    End Module
