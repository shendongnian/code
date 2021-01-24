using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
namespace nuVoid.Architecture.EntityFramework
{
  public class GenericOrder<TEntity> : IOrder<TEntity> where TEntity : class, new()
  {
    public string Property { get; set; }
    public bool Reverse { get; set; }
    public GenericOrder()
    {
    }
    public GenericOrder(string property, bool reverse)
    {
      this.Property = property;
      this.Reverse = reverse;
    }
    public virtual IOrderedQueryable<TEntity> Apply(IQueryable<TEntity> query)
    {
      return this.CreateOrderFunc()(query);
    }
    protected virtual Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> CreateOrderFunc()
    {
      if (string.IsNullOrWhiteSpace(this.Property))
        throw new InvalidOperationException("no valid property set");
      string methodName = this.Reverse ? "OrderByDescending" : "OrderBy";
      Type type = typeof (TEntity);
      PropertyInfo property = type.GetProperty(this.Property);
      Type propertyType = property.PropertyType;
      ParameterExpression parameterExpression1 = Expression.Parameter(type, "x");
      LambdaExpression lambdaExpression = Expression.Lambda((Expression) Expression.Property((Expression) parameterExpression1, property), parameterExpression1);
      ParameterExpression parameterExpression2;
      return ((Expression<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>>)(p => Expression.Call(typeof(Queryable), methodName, new Type[2]
      {
        type,
        propertyType
      }, (Expression)parameterExpression2, (Expression)Expression.Quote((Expression)lambdaExpression)))).Compile();
    }
  }
}
