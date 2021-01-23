    Public Class ParameterRebinder
        Inherits Expressions.ExpressionVisitor
    
        Private ReadOnly map As Dictionary(Of Expressions.ParameterExpression, Expressions.ParameterExpression)
    
        Public Sub New(ByVal map As Dictionary(Of Expressions.ParameterExpression, Expressions.ParameterExpression))
            Me.map = If(map, New Dictionary(Of Expressions.ParameterExpression, Expressions.ParameterExpression)())
        End Sub
    
        Public Shared Function ReplaceParameters(ByVal map As Dictionary(Of Expressions.ParameterExpression, Expressions.ParameterExpression), ByVal exp As Expressions.Expression) As Expressions.Expression
            Return New ParameterRebinder(map).Visit(exp)
        End Function
    
        Protected Overloads Overrides Function VisitParameter(ByVal p As Expressions.ParameterExpression) As Expressions.Expression
            Dim replacement As Expressions.ParameterExpression = Nothing
            If map.TryGetValue(p, replacement) Then
                p = replacement
            End If
            Return MyBase.VisitParameter(p)
        End Function
    End Class
