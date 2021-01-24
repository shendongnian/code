    if (!String.IsNullOrEmpty(sOrdenar))
    {
        var type = typeof(Clientes_view);
		var prop = type.GetProperty(sOrdenar);
		if (prop != null)
		{
	        var param = Expression.Parameter(type);
	        var expr = Expression.Lambda<Func<Clientes_view, object>>(
				Expression.Convert(Expression.Property(param, prop), typeof(object)),
				param
			);
	        if (nSentido == -1)
				clientes = clientes.OrderByDescending(expr);
	        else
				clientes = clientes.OrderBy(expr);
		}
    }
