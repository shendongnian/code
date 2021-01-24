     var query = QueryBuilder.Select(SelectResult.expression(Meta.id),
                    SelectResult.expression(Expression.property("id")))
        .From(DataSource.Database(db))
    .Where(Expression.Property("name").NotNullOrMissing()
    .And(Expression.Property("name").EqualTo(Expression.string("My first test"))))
