    Public Shared Iterator Function Partition(Of T)(source As IList(Of T), Optional size As Int32 = 1000) As IEnumerable(Of List(Of T))
            For i As Integer = 0 To CInt(Math.Ceiling(source.Count / CDbl(size)))
                Yield New List(Of T)(source.Skip(size * i).Take(size))
            Next
    End Function
