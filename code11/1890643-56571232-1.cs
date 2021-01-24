	Expression<Func<Person, bool>> e1 = p => p.Comment.Contains(searchWords[0]);
	Expression<Func<Person, bool>> e2 = p => p.Comment.Contains(searchWords[1]);
	Expression<Func<Person, bool>> e3 = p => p.Comment.Contains(searchWords[2]);
	var orExpression1 = Expression.OrElse(e1.Body, Expression.Invoke(e2, e1.Parameters[0]));
	var orExpression2 = Expression.OrElse(orExpression1, Expression.Invoke(e3, e1.Parameters[0]));
	var finalExpression = Expression.Lambda<Func<Person, bool>>(orExpression2, e1.Parameters);	
