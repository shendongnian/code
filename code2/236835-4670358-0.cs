    public class Account : Base
    {
      ...
      public override Expression<Func<T, bool>> MustNotAlreadyExist()
      {
        return (b => b.Name == name && b.AccountCode == accountCode).Any();
      }
      ...
    }
