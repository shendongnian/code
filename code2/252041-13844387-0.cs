    public abstract class Activity<TEntity>
    {
      public Activity() { }
      protected virtual object Implementation { ... }
    }
    public abstract class CompensableActivity<TEntity,TCompensation> : Activity<TEntity>
      where TCompensation : Activity<T>, new()
    {
      public CompensableActivity() { }
      protected override object Implementation
      {
        get { new Wrapper(base.Implementation, Compensation); }
      }
      private Activity<TEntity> Compensation
      {
        get
        {
          var compensation = new TCompensation();
          if(compensation is CompensableActivity<TEntity,Activity<TEntity>)
          {
            // Activity<TEntity> "does not meet new() constraint" !
            var compensable = comp as CompensableActivity<TEntity, Activity<TEntity>>;
            var implement = compensable.Implementation as Wrapper;
            return implement.NormalActivity;
          }
          else { return compensation; }
        }
      }
    }
