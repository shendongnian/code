    Public Class MyQueryProvider
       Implements IQueryProvider
       Private innerProvider As IQueryProvider
       Public Sub New(ByVal innerProvider As IQueryProvider)
          Me.innerProvider = innerProvider
       End Sub
       Public Function CreateQuery(ByVal expression As System.Linq.Expressions.Expression) As System.Linq.IQueryable Implements System.Linq.IQueryProvider.CreateQuery
          Return innerProvider.CreateQuery(expression)
       End Function
       Public Function CreateQuery1(Of TElement)(ByVal expression As System.Linq.Expressions.Expression) As System.Linq.IQueryable(Of TElement) Implements System.Linq.IQueryProvider.CreateQuery
          Dim newQuery = innerProvider.CreateQuery(Of TElement)(ConvertExpression(expression))
          If TypeOf newQuery Is IOrderedQueryable(Of TElement) Then
             Return New MyOrderedQueryable(Of TElement)(DirectCast(newQuery, IOrderedQueryable(Of TElement)))
          Else
             Return New MyQueryable(Of TElement)(newQuery)
          End If
       End Function
       Public Shared Function ConvertExpression(ByVal expression As Expression) As Expression
          If TypeOf expression Is MethodCallExpression Then
             Dim mexp = DirectCast(expression, MethodCallExpression)
             Return Expressions.MethodCallExpression.Call(ConvertExpression(mexp.Object), _
                mexp.Method, (From row In mexp.Arguments Select ConvertExpression(row)).ToArray())
          ElseIf TypeOf expression Is BinaryExpression Then
             Dim bexp As BinaryExpression = DirectCast(expression, BinaryExpression)
             Dim memberInfo As NestedMember = Nothing
             Dim constExp As Expression = Nothing
             Dim memberOnLeft As Boolean
             Dim doConvert = True
             '' [etc... lots of code to generate a manipulated expression tree
          ElseIf TypeOf expression Is LambdaExpression Then
             Dim lexp = DirectCast(expression, LambdaExpression)
             Return LambdaExpression.Lambda( _
                ConvertExpression(lexp.Body), (From row In lexp.Parameters Select _
                DirectCast(ConvertExpression(row), ParameterExpression)).ToArray())
          ElseIf TypeOf expression Is ConditionalExpression Then
             Dim cexp = DirectCast(expression, ConditionalExpression)
             Return ConditionalExpression.Condition(ConvertExpression(cexp.Test), _
                                                    ConvertExpression(cexp.IfTrue), _
                                                    ConvertExpression(cexp.IfFalse))
          ElseIf TypeOf expression Is InvocationExpression Then
             Dim iexp = DirectCast(expression, InvocationExpression)
             Return InvocationExpression.Invoke( _
                ConvertExpression(iexp.Expression), (From row In iexp.Arguments _
                Select ConvertExpression(row)).ToArray())
          ElseIf TypeOf expression Is MemberExpression Then
             '' [etc... lots of code to generate a manipulated expression tree
          ElseIf TypeOf expression Is UnaryExpression Then
             '' [etc... lots of code to generate a manipulated expression tree
          Else
             Return expression
          End If
       End Function
       Public Function Execute(ByVal expression As System.Linq.Expressions.Expression) As Object Implements System.Linq.IQueryProvider.Execute
          Return innerProvider.Execute(expression)
       End Function
       Public Function Execute1(Of TResult)(ByVal expression As System.Linq.Expressions.Expression) As TResult Implements System.Linq.IQueryProvider.Execute
          Return innerProvider.Execute(Of TResult)(ConvertExpression(expression))
       End Function
    End Class
