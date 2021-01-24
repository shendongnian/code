            dynamic applicationOrderByObject = _mapper.MapExpression(orderBy,
                typeof(Expression<Func<IQueryable<PresentationModelPerson>, IOrderedQueryable<PresentationModelPerson>>>
                ),
                typeof(Expression<Func<IQueryable<ApplicationModelPerson>, IOrderedQueryable<ApplicationModelPerson>>
                >));
