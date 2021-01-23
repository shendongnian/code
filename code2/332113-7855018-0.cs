    public static void UpdateReferences<FK, FKV>(
        this EntitySet<FK> refs,
        Expression<Func<FK, FKV>> fkexpr,
        IEnumerable<FKV> values)
      where FK : class
      where FKV : class
    {
      Func<FK, FKV> fkvalue = fkexpr.Compile();
      var fkmaker = MakeMaker(fkexpr);
      var fkdelete = MakeDeleter(fkexpr);
      var fks = refs.Select(fkvalue).ToList();
      var added = values.Except(fks);
      var removed = fks.Except(values);
      foreach (var add in added)
      {
        refs.Add(fkmaker(add));
      }
      foreach (var r in removed)
      {
        var res = refs.Single(x => fkvalue(x) == r);
        refs.Remove(res);
        fkdelete(res);
      }
    }
    static Func<FKV, FK> MakeMaker<FKV, FK>(Expression<Func<FK, FKV>> fkexpr)
    {
      var me = fkexpr.Body as MemberExpression;
      var par = Expression.Parameter(typeof(FKV), "fkv");
      var maker = Expression.Lambda(
          Expression.MemberInit(Expression.New(typeof(FK)),
            Expression.Bind(me.Member, par)), par);
      var cmaker = maker.Compile() as Func<FKV, FK>;
      return cmaker;
    }
    static Action<FK> MakeDeleter<FK, FKV>(Expression<Func<FK, FKV>> fkexpr)
    {
      var me = fkexpr.Body as MemberExpression;
      var pi = me.Member as PropertyInfo;
      var assoc = Attribute.GetCustomAttribute(pi, typeof(AssociationAttribute))
        as AssociationAttribute;
      if (assoc == null || !assoc.DeleteOnNull)
      {
        throw new ArgumentException("DeleteOnNull must be set to true");
      }
      var par = Expression.Parameter(typeof(FK), "fk");
      var maker = Expression.Lambda(
          Expression.Call(par, pi.GetSetMethod(),
            Expression.Convert(Expression.Constant(null), typeof(FKV))), par);
      var cmaker = maker.Compile() as Action<FK>;
      return cmaker;
    }
