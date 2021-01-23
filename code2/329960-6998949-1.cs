	protected override Expression VisitMember(MemberExpression node) {
		if (node.Expression.NodeType == ExpressionType.Constant) {
			var inner = (ConstantExpression)node.Expression;
			var value = (node.Member as FieldInfo).GetValue(inner.Value);
		}
		return base.VisitMember(node);
	}
