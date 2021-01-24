    <System.Runtime.CompilerServices.Extension>
    Public Function ForEachAsync(Of T)(
        source As IEnumerable(Of T),
        body As Func(Of T, Task)) As Task
        Return Task.WhenAll(        
            From item In source
            Select body(item))
    End Function
