    public class DerivedRepository : Repository
    {
      public DerivedRepository(DbContext context)
        : base(context) { }
      protected override void RegisterIncludes(Dictionary<Type, LambdaExpression[]> includes)
      {
        includes.Add(typeof(ParentType), new Expression<Func<ParentType, object>>[] { 
          p => p.SomeChildReference.SomeGrandchild,
          p => p.SomeOtherChildReference
        });
      }
    }
