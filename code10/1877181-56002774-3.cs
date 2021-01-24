    <Extension>
    Public Function ForEachAsync(Of T)(source As IEnumerable(Of T), dop As Integer, body As Func(Of T, Task)) As Task
        Return Task.WhenAll(
            Partitioner.Create(source).GetPartitions(dop).
            Select(Function(p) (
                       Task.Run(Async Function()
                                    Using p
                                        While p.MoveNext()
                                            Await body(p.Current)
                                        End While
                                    End Using
                                End Function))))
    End Function
