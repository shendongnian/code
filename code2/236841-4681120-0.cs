    public interface IUniqueable<T>
    {
      Expression<Func<T, bool>> Unique { get; }
    }
    
    public class Base, IUniqueable<Base>
    {
      ...
      public Expression<Func<Base, bool>> Unique
      {
        get
        {
          var xParam = Expression.Parameter(typeof(Base), typeof(Base).Name);
          MemberExpression leftExprFieldCheck = MemberExpression.Property(xParam, "Name");
          Expression rightExprFieldCheck = Expression.Constant(this.Name);
          BinaryExpression binaryExprFieldCheck = MemberExpression.Equal(leftExprFieldCheck, rightExprFieldCheck);
          return Expression.Lambda<Func<Base, bool>>(binaryExprFieldCheck, new ParameterExpression[] { xParam });
        }
      }
      ...
    }
    
    public class Account : Base, IUniqueable<Account>
    {
      ...
      public new Expression<Func<Account, bool>> Unique
      {
        get
        {
          var xParam = Expression.Parameter(typeof(Account), typeof(Account).Name);
          MemberExpression leftExprNameCheck = MemberExpression.Property(xParam, "Name");
          Expression rightExprNameCheck = Expression.Constant(this.Name);
          BinaryExpression binaryExprNameCheck = MemberExpression.Equal(leftExprNameCheck, rightExprNameCheck);
    
          MemberExpression leftExprFieldCheck = MemberExpression.Property(xParam, "AccountCode");
          Expression rightExprFieldCheck = Expression.Constant(this.AccountCode);
          BinaryExpression binaryExprFieldCheck = MemberExpression.Equal(leftExprFieldCheck, rightExprFieldCheck);
    
          BinaryExpression binaryExprAllCheck = Expression.Or(binaryExprNameCheck, binaryExprFieldCheck);
    
          return Expression.Lambda<Func<Account, bool>>(binaryExprAllCheck, new ParameterExpression[] { xParam });
        }
      }
      ...
    }
    
    public static class Manager
    {
      ...
      public static T Save<T>(T item) where T : Base, new()
      {
        if (!item.IsValid)
        {
          throw new ValidationException("Unable to save item, item is not valid", item.GetRuleViolations());
        }
    
        if (item.Id == Guid.Empty && repository.GetAll<T>().Any(((IUniqueable<T>)item).Unique))
        {
          throw new Exception("Item is not unique");
        }
    
        return repository.Save<T>(item);
      }
      ...
    }
