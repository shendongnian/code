    Public Class MyQueryable(Of TableType)
       Implements IQueryable(Of TableType)
       Private innerQueryable As IQueryable(Of TableType)
       Private myProvider As MyQueryProvider = Nothing
       Public Sub New(ByVal innerQueryable As IQueryable(Of TableType))
          Me.innerQueryable = innerQueryable
       End Sub
       Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of TableType) Implements System.Collections.Generic.IEnumerable(Of TableType).GetEnumerator
          Return innerQueryable.GetEnumerator()
       End Function
       Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
          Return innerQueryable.GetEnumerator()
       End Function
       Public ReadOnly Property ElementType() As System.Type Implements System.Linq.IQueryable.ElementType
          Get
             Return innerQueryable.ElementType
          End Get
       End Property
       Public ReadOnly Property Expression() As System.Linq.Expressions.Expression Implements System.Linq.IQueryable.Expression
          Get
             Return innerQueryable.Expression
          End Get
       End Property
       Public ReadOnly Property Provider() As System.Linq.IQueryProvider Implements System.Linq.IQueryable.Provider
          Get
             If myProvider Is Nothing Then myProvider = New MyQueryProvider(innerQueryable.Provider)
             Return myProvider
          End Get
       End Property
       Friend ReadOnly Property innerTable() As System.Data.Linq.ITable
          Get
             If TypeOf innerQueryable Is System.Data.Linq.ITable Then
                Return DirectCast(innerQueryable, System.Data.Linq.ITable)
             End If
             Throw New InvalidOperationException("Attempted to treat a MyQueryable as a table that is not a table")
          End Get
       End Property
    End Class
