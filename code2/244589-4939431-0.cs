    Expression<Func<TParentEntity, TChildEntity, bool>> joinExpr =
        ctx.GetJoinExpression<TParentEntity, TChildEntity>();
    
    Expression<Func<TChildEntity, bool>> childSelectionExpression =
        GetExpression<TChildEntity>(ctx);
    
    return
        (from parentEntity in ctx.GetQueryable<TParentEntity>()
            .AsExpandable()
        let childEntities = 
            from child in ctx.GetQueryable<TChildEntity>()
            where joinExpr.Invoke(parentEntity, child)
            select child
        select parentEntity).Where(childSelectionExpression);
