        class Foo<T> {
                public string Bar<T, TResult>(Expression<Func<T, TResult>> expersion)
        		{
        			var lambda = (LambdaExpression)expersion;
        			MemberExpression memberExpression;
        			if (lambda.Body is UnaryExpression)
        			{
		        		var unaryExpression = (UnaryExpression)lambda.Body;
				        memberExpression = (MemberExpression)unaryExpression.Operand;
        			}
		        	else
			        {
				        memberExpression = (MemberExpression)lambda.Body;
			        }
			        return memberExpression.Member.Name;
		        }
        }
