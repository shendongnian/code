    Protected Overrides Function VisitMemberAccess(ByVal m As MemberExpression) As Expression
        If Not m.Member.DeclaringType Is GetType(TSource) Then
            ' We are accessing a member/variable on a class
            ' We need to descend the tree through the navigation properties and eventually derive a constant expression
            Return Me.VisitMemberAccess(m, m.Type)
        End If
        Return ' I had custom logic here which you shouldn't need
    End Function
    
    Protected Overloads Function VisitMemberAccess(ByVal m As MemberExpression, ByVal expectedType As Type) As Expression
        If m.Expression.NodeType = ExpressionType.Constant Then
            ' We are at the end of the member expression 
            ' i.e. MyClass.Something.Something.Value <-- we're at the Value part now
            Dim constant As ConstantExpression = DirectCast(m.Expression, ConstantExpression)
            Return Expression.Constant(m.Expression.Type.GetFields().Single(Function(n) n.FieldType Is expectedType AndAlso m.Member.Name.Contains(n.Name)).GetValue(constant.Value))
        ElseIf m.Member.DeclaringType Is GetType(TSource) Then
            ' I had custom logic here that I think you can ignore
        ElseIf m.Member.DeclaringType Is GetType(Nullable) Then
            ' never got round to implementing this as we don't need it yet
        Else
            ' continue walking the member access until we derive the constant
            Return Me.VisitMemberAccess(DirectCast(m.Expression, MemberExpression), expectedType)
        End If
    End Function
