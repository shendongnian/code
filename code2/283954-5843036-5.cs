    var id = 1;
    var text = db.Texts.Where(t => t.TextId == id).OrderBy(CreatePriorityExpression()).FirstOrDefault();
    private static Expression<Func<Text, int>> CreatePriorityExpression()
    {
        var languages = new[]
                            {
                                new {Language = "Danish", Priority = 1},
                                new {Language = "English", Priority = 2}
                            };
    
        // Creates an expression of nested if-else statements & translates to a SQL CASE statement.
        var pt = Expression.Parameter(typeof (Text));
        var pl = Expression.PropertyOrField(pt, "Language");
        Expression ex = Expression.Constant(languages.Last().Priority);
        ex = languages.Reverse().Skip(1)
            .Aggregate(ex,
                        (c, l) =>
                        Expression.Condition(Expression.Equal(pl, Expression.Constant(l.Language)),
                                            Expression.Constant(l.Priority), c));
        return Expression.Lambda<Func<Text, int>>(ex, pt);
    }
