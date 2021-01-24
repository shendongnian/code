c#
public Expression<Func<Container, bool>> IsContainerMatch => c => Selector(c.Item) == Value;
IsContainerMatch is a property, returning a new instance of an expression on each get. The expression contains constant references to the Instance to access Value and Selector. This is roughly equivalent to;
c#
public Expression<Func<Container, bool>> IsContainerMatch { get {
    var inst = Expression.Constant(this);
    var container = Expression.Parameter(typeof(Container), "c");
    var selector = typeof(Instance).GetProperty("Selector");
    var value = typeof(Instance).GetProperty("Value");
    var item = typeof(Container).GetProperty("Item");
    return Expression.Lambda<Func<Container, bool>>(
    	Expression.Equal(
    		Expression.Invoke(
    			Expression.MakeMemberAccess(inst, selector),
    			Expression.MakeMemberAccess(container, item)
    			),
    		Expression.MakeMemberAccess(inst, value)
    		),
    	container
    );
} }
This is unlikely to be the true source of your exception. Somewhere else a new LambdaExpression has been constructed, perhaps from pieces of this Expression, with a reference to this ParameterExpression 'C'. But with a different parameter.
For example something like this might cause that Exception;
c#
    ...
    return Expression.Lambda<Func<Container, bool>>(
    	Expression.Equal(
    		Expression.Invoke(
    			Expression.MakeMemberAccess(inst, selector),
    			Expression.MakeMemberAccess(Expression.Parameter(typeof(Container), "X"), item)
    			),
    		Expression.MakeMemberAccess(inst, value)
    		),
    	Expression.Parameter(typeof(Container), "Y")
    );
Clearly you are attempting to use a type of Expression that your 3rd party library doesn't support.
Now that you've updated the question to include NHibernate, it seems like what you're trying to achieve is;
foreach (var element in instanceList) query.And(c => c.Item.[Dynamic member] == element.Value);
So that the criteria can be evaluated efficiently by NHibernate. But since your Selector is a compiled Func, there's no way for NHibernate to look inside that method and translate this into an efficient query.
