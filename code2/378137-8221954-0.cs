    Public Shared Function GetSingleRandom(Of T)(ByVal target As IEnumerable(Of T)) As T
            Dim r As New Random(DateTime.Now.Millisecond)
            Dim position As Integer = r.Next(target.Count)
            Return target.ElementAt(position)
        End Function
