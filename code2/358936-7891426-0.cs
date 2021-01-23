	public class MyQueryTranslator : ExpressionVisitor
	{
		public MyQueryTranslator()
		{
		}
		public void Translate(Expression expression)
		{
			this.Visit(expression);
		}
		private static Expression StripQuotes(Expression e)
		{
			while (e.NodeType == ExpressionType.Quote)
			{
				e = ((UnaryExpression)e).Operand;
			}
			return e;
		}
		protected override Expression VisitMethodCall(MethodCallExpression m)
		{
			if (m.Method.DeclaringType == typeof(Queryable) && m.Method.Name == "Where")
			{
				this.Visit(m.Arguments[0]);
				LambdaExpression lambda = (LambdaExpression)StripQuotes(m.Arguments[1]);
				this.Visit(lambda.Body);
				return m;
			}
			else if (m.Method.Name == "Take")
			{
				if (this.ParseTakeExpression(m))
				{
					Expression nextExpression = m.Arguments[0];
					return this.Visit(nextExpression);
				}
			}
			else if (m.Method.Name == "Skip")
			{
				if (this.ParseSkipExpression(m))
				{
					Expression nextExpression = m.Arguments[0];
					return this.Visit(nextExpression);
				}
			}
			else if (m.Method.Name == "OrderBy")
			{
				if (this.ParseOrderByExpression(m, "ASC"))
				{
					Expression nextExpression = m.Arguments[0];
					return this.Visit(nextExpression);
				}
			}
			else if (m.Method.Name == "OrderByDescending")
			{
				if (this.ParseOrderByExpression(m, "DESC"))
				{
					Expression nextExpression = m.Arguments[0];
					return this.Visit(nextExpression);
				}
			}
			throw new NotSupportedException(string.Format("The method '{0}' is not supported", m.Method.Name));
		}
		protected override Expression VisitUnary(UnaryExpression u)
		{
			switch (u.NodeType)
			{
				case ExpressionType.Not:
					this.Visit(u.Operand);
					break;
				case ExpressionType.Convert:
					this.Visit(u.Operand);
					break;
				default:
					throw new NotSupportedException(string.Format("The unary operator '{0}' is not supported", u.NodeType));
			}
			return u;
		}
		protected override Expression VisitBinary(BinaryExpression b)
		{
			this.Visit(b.Left);
			switch (b.NodeType)
			{
				case ExpressionType.And:
					break;
				case ExpressionType.AndAlso:
					break;
				case ExpressionType.Or:
					break;
				case ExpressionType.OrElse:
					break;
				case ExpressionType.Equal:
					if (IsNullConstant(b.Right))
					{
						
					}
					else
					{
						
					}
					break;
				case ExpressionType.NotEqual:
					if (IsNullConstant(b.Right))
					{
						
					}
					else
					{
						
					}
					break;
				case ExpressionType.LessThan:
					
					break;
				case ExpressionType.LessThanOrEqual:
					break;
				case ExpressionType.GreaterThan:
					
					break;
				case ExpressionType.GreaterThanOrEqual:
					
					break;
				default:
					throw new NotSupportedException(string.Format("The binary operator '{0}' is not supported", b.NodeType));
			}
			this.Visit(b.Right);
			return b;
		}
		protected override Expression VisitConstant(ConstantExpression c)
		{
			IQueryable q = c.Value as IQueryable;
			if (q == null && c.Value == null)
			{
				
			}
			else if (q == null)
			{
				switch (Type.GetTypeCode(c.Value.GetType()))
				{
					case TypeCode.Boolean:
						break;
					case TypeCode.String:
						break;
					case TypeCode.DateTime:
						break;
					case TypeCode.Object:
						throw new NotSupportedException(string.Format("The constant for '{0}' is not supported", c.Value));
					default:
						break;
				}
			}
			return c;
		}
		protected override Expression VisitMember(MemberExpression m)
		{
			if (m.Expression != null && m.Expression.NodeType == ExpressionType.Parameter)
			{
				return m;
			}
			throw new NotSupportedException(string.Format("The member '{0}' is not supported", m.Member.Name));
		}
		protected bool IsNullConstant(Expression exp)
		{
			return (exp.NodeType == ExpressionType.Constant && ((ConstantExpression)exp).Value == null);
		}
		private bool ParseOrderByExpression(MethodCallExpression expression, string order)
		{
			UnaryExpression unary = (UnaryExpression)expression.Arguments[1];
			LambdaExpression lambdaExpression = (LambdaExpression)unary.Operand;
			// Send the lambda expression through the partial evaluator.
			lambdaExpression = (LambdaExpression)Evaluator.PartialEval(lambdaExpression);
			MemberExpression body = lambdaExpression.Body as MemberExpression;
			if (body != null)
			{
				// Set order by
				return true;
			}
			return false;
		}
		private bool ParseTakeExpression(MethodCallExpression expression)
		{
			ConstantExpression sizeExpression = (ConstantExpression)expression.Arguments[1];
			int size;
			if (int.TryParse(sizeExpression.Value.ToString(), out size))
			{
				return true;
			}
			return false;
		}
		private bool ParseSkipExpression(MethodCallExpression expression)
		{
			ConstantExpression sizeExpression = (ConstantExpression)expression.Arguments[1];
			int size;
			if (int.TryParse(sizeExpression.Value.ToString(), out size))
			{
				return true;
			}
			return false;
		}
	}
