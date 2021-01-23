    Imports System.Runtime.CompilerServices
    
    Module Module1
        <Extension()>
        Private Function CartesianProduct(Of T)(
                ByVal sequences As IEnumerable(Of IEnumerable(Of T))) _
                As IEnumerable(Of IEnumerable(Of T))
            Dim emptyProduct As IEnumerable(Of IEnumerable(Of T)) =
                New IEnumerable(Of T)() {Enumerable.Empty(Of T)()}
            Return sequences.Aggregate(
                emptyProduct,
                Function(accumulator, sequence)
                    Return (From accseq In accumulator
                            From item In sequence
                            Select accseq.Concat(New T() {item}))
                End Function)
        End Function
    
        Sub Main(ByVal args As String())
            Dim items = New Integer()() {New Integer() {11001, 54010, 60621},
                                         New Integer() {11001, 60621},
                                         New Integer() {60621}}
            Dim routes = items.CartesianProduct()
            Dim route As IEnumerable(Of Integer)
            For Each route In routes
                Console.WriteLine(String.Join(", ", route))
            Next
        End Sub
    End Module
