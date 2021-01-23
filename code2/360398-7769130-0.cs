    public class AandB
    {
      public A TheA {get;set;}
      public B TheB {get;set;}
    }
    
    IQueryable<A> queryA =  dc.TblA.AsQueryable();
    
    IQueryable<AandB> queryAandB = null;
    
    if (checkCondition)
    {
      //inner join
      queryAandB = queryA
        .Join(
          GetMyTable(),
          a => a.Ref, b => b.RefA,
          (a, b) => new AandB() {TheA = a, TheB = b}
        );
    }
    else
    {
      // left join
      queryAandB = queryA
        .GroupJoin(
          GetMyTable(),
          a => a.Ref, b => b.RefA,
          (a, g) => new {a, g}
        )
        .SelectMany(
          x => x.g.DefaultIfEmpty(),
          (x, b) => new AandB(){TheA = x.a, TheB = b}
        );
    }
    List<AandB> results = queryAandB.ToList();
