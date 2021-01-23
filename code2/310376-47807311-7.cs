    <Extension>
    <DebuggerStepThrough>
    Public Sub RemoveDuplicates(Of T As IComparable(Of T))(Instance As List(Of T))
      Instance.RemoveDuplicates(Function(X, Y) X.CompareTo(Y))
    End Sub
