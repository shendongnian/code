c#
public class BlogSummaryViewModel
{
    public string Name { get; set; }
    public static Expression<Func<Data.Blog, BlogSummaryViewModel>> Map()
    {
        return (i => new BlogSummaryViewModel
        {
            Name = i.Name
        });
    }
}
public class BlogViewModel : BlogSummaryViewModel
{
    public int PostCount { get; set; }
    public static Expression<Func<Data.Blog, BlogViewModel>> Map()
    {
        return (i => new BlogViewModel
        {
            Name = i.Name,
            PostCount = i.Posts.Count()
        });
    }
}
I adapted the solution provided by @Marc Gravell like so:
c#
public static class ExpressionMapExtensions
{
    public static Expression<Func<TSource, TTargetB>> Join<TSource, TTargetA, TTargetB>(
        this Expression<Func<TSource, TTargetA>> mapA, Expression<Func<TSource, TTargetB>> mapB)
        where TTargetB : TTargetA
    {
        var param = Expression.Parameter(typeof(TSource), "i");
        return Expression.Lambda<Func<TSource, TTargetB>>(
            Expression.MemberInit(
                ((MemberInitExpression)mapB.Body).NewExpression,
                (new LambdaExpression[] { mapA, mapB }).SelectMany(e =>
                {
                    var bindings = ((MemberInitExpression)e.Body).Bindings.OfType<MemberAssignment>();
                    return bindings.Select(b =>
                    {
                        var paramReplacedExp = new ParameterReplaceVisitor(e.Parameters[0], param).VisitAndConvert(b.Expression, "Combine");
                        return Expression.Bind(b.Member, paramReplacedExp);
                    });
                })),
            param);
    }
    private class ParameterReplaceVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression original;
        private readonly ParameterExpression updated;
        public ParameterReplaceVisitor(ParameterExpression original, ParameterExpression updated)
        {
            this.original = original;
            this.updated = updated;
        }
        protected override Expression VisitParameter(ParameterExpression node) => node == original ? updated : base.VisitParameter(node);
    }
}
The `Map` method of the extended class then becomes:
c#
    public static Expression<Func<Data.Blog, BlogViewModel>> Map()
    {
        return BlogSummaryViewModel.Map().Join(i => new BlogViewModel
        {
            PostCount = i.Posts.Count()
        });
    }
