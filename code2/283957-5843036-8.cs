    var id = 1;
    var text = db.Texts.Where(t => t.TextId == id).OrderBy(CreatePriorityExpression()).FirstOrDefault();
    private static Expression<Func<Text, int>> CreatePriorityExpression()
    {
        var languages = new[]
                            {
                                new {Language = "Danish", Priority = 1},
                                new {Language = "English", Priority = 2}
                            };
    
        // Creates an expression of nested if-else statements & translates to a SQL CASE 
        var param = Expression.Parameter(typeof(Text));
        var lang = Expression.PropertyOrField(param, "Language");
        Expression ex = Expression.Constant(languages.Last().Priority);
        foreach (var l in languages.Reverse().Skip(1))
            ex = Expression.Condition(Expression.Equal(lang, Expression.Constant(l.Language)), Expression.Constant(l.Priority), ex);
        return Expression.Lambda<Func<Text, int>>(ex, param);
    }
