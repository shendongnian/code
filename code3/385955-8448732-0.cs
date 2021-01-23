	Protected Overrides Function VisitMemberAccess(ByVal m As MemberExpression) As Expression
		If Not m.Member.DeclaringType Is GetType(TSource) Then
			' We are accessing a member/variable on a class
			' We need to descend the tree through the navigation properties and eventually derive a constant expression
			Return Me.VisitMemberAccess(m, m.Type)
		End If
		Return ConvertMemberAccess(m)
	End Function
	Protected Overloads Function VisitMemberAccess(ByVal m As MemberExpression, ByVal expectedType As Type) As Expression
		If m.Expression.NodeType = ExpressionType.Constant Then
			Dim constant As ConstantExpression = DirectCast(m.Expression, ConstantExpression)
			Return Expression.Constant(m.Expression.Type.GetFields().Single(Function(n) n.FieldType Is expectedType AndAlso m.Member.Name.Contains(n.Name)).GetValue(constant.Value))
		ElseIf m.Member.DeclaringType Is GetType(TSource) Then
			' I had custom logic here that I think you can ignore
		ElseIf m.Member.DeclaringType Is GetType(Nullable) Then
			' never got round to implementing this as we didn't need it yet
		Else
			Return Me.VisitMemberAccess(DirectCast(m.Expression, MemberExpression), expectedType)
		End If
	End Function
