    Imports Microsoft.VisualBasic
    Imports System.Web.Compilation
    Imports System.CodeDom
    
    <ExpressionPrefix("Code")> _
    Public Class CodeExpressionBuilder
        Inherits ExpressionBuilder
    
        Public Overrides Function GetCodeExpression(ByVal entry As BoundPropertyEntry, ByVal parsedData As Object, ByVal context As ExpressionBuilderContext) As CodeExpression
            Return New CodeSnippetExpression(entry.Expression)
        End Function
    
    End Class
