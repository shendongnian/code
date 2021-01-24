// OnModelCreating
  var methodInfo = typeof(DemoDbContext).GetMethod(nameof(DemoRowNumber));
  modelBuilder.HasDbFunction(methodInfo)
            .HasTranslation(expressions => {
                 var partitionBy = (Expression[])((ConstantExpression)expressions.First()).Value;
                 var orderBy = (Expression[])((ConstantExpression)expressions.Skip(1).First()).Value;
                 return new RowNumberExpression(partitionBy, orderBy);
});
// the usage with this approach is identical to my current approach
.Select(c => new {
    RowNumber = DemoDbContext.DemoRowNumber(
                                  new { c.Id },
                                  new { c.RowVersion })
    })
**2)** An anonymous type can’t enforce the type(s) of its members, so you can get a runtime exception if the function is called with, say, `integer` instead of `string`. Still, it can be valid solution. Depending on the customer you are working for the solution may be more or less viable, in the end the decision lies with the customer. Not providing any alternatives is a possible solution as well but not a satisfying one. 
Especially, if the usage of SQL is not desired (because you get even less support from compiler) so the runtime exception may be a good compromise after all.
But, if the compromise is still not acceptable then we can make a research on how to add support for arrays. 
First approach could be the implementation of a custom ` IExpressionFragmentTranslator` to “redirect” the handling of arrays to us.
> Please note, it is just a prototype and needs more investigation/testing :-)
// to get into EF pipeline
public class DemoArrayTranslator : IExpressionFragmentTranslator
{
    public Expression Translate(Expression expression)
    {
       if (expression?.NodeType == ExpressionType.NewArrayInit)
       {
          var arrayInit = (NewArrayExpression)expression;
          return new DemoArrayInitExpression(arrayInit.Type, arrayInit.Expressions);
       }
       return null;
    }
}
// lets visitors visit the array-elements
public class DemoArrayInitExpression : Expression
{
   private readonly ReadOnlyCollection<Expression> _expressions;
   public override Type Type { get; }
   public override ExpressionType NodeType => ExpressionType.Extension;
   public DemoArrayInitExpression(Type type, 
           ReadOnlyCollection<Expression> expressions)
   {
      Type = type ?? throw new ArgumentNullException(nameof(type));
      _expressions = expressions ?? throw new ArgumentNullException(nameof(expressions));
   }
   protected override Expression Accept(ExpressionVisitor visitor)
   {
      var visitedExpression = visitor.Visit(_expressions);
      return NewArrayInit(Type.GetElementType(), visitedExpression);
   }
}
// adds our DemoArrayTranslator to the others
public class DemoRelationalCompositeExpressionFragmentTranslator 
      : RelationalCompositeExpressionFragmentTranslator
{
    public DemoRelationalCompositeExpressionFragmentTranslator(
             RelationalCompositeExpressionFragmentTranslatorDependencies dependencies)
         : base(dependencies)
      {
         AddTranslators(new[] { new DemoArrayTranslator() });
      }
   }
// Register the translator
services
  .AddDbContext<DemoDbContext>(builder => builder
       .ReplaceService<IExpressionFragmentTranslator,
                       DemoRelationalCompositeExpressionFragmentTranslator>());
For testing I introduced another overload containing `Guid[]` as parameter.
*Although, this method doesn't make sense in my use case at all :)*
public static long RowNumber(this DbFunctions _, Guid[] orderBy) 
And adjusted the usage of the method
// Translates to ROW_NUMBER() OVER(ORDER BY Id)
.Select(c => new { 
                RowNumber = EF.Functions.RowNumber(new Guid[] { c.Id })
}) 
