    Imports System.Collections.Concurrent
    Public Class SortedConcurrentDictionary(Of TKey, Tvalue)
    Inherits ConcurrentDictionary(Of TKey, Tvalue)
        Shadows ReadOnly Property Values As IEnumerable(Of Tvalue)
            Get
                If MyBase.Values.Count = 0 Then
                    Return MyBase.Values
                End If
                Return From k In Keys Order By k Select Me(k)
            End Get
        End Property
    End Class
