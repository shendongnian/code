    public class C
    {
      A TheA {get;set;}
      List<B> TheBs {get;set;}
    }
    //g is an IEnumerable<B> with a key property of A
    List theResult =
    (
      from a in ListA
      join b in ListB on a.ValueAB = b.ValueAB into g
      select new C()
     {
        TheA = g.Key,
        TheBs = g.ToList()
      }
    ).ToList();
  
