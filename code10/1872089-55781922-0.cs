public TBL1 TBL1 { get; set; }
Add a projection to your TBL1 model like this: 
public static Expression<Func<TBL1, TBL2>> Projection
{
    return tbl1 => new TBL2
    {
        Prop1 = tbl1.Prop1,
        Prop2 = tbl1.Prop2,
        TBL1 = tbl1,
    };
}
And use the projection to have instances of TBL1 and TBL2 like this:
var MyEntity = new MyEntities();
var tbl2 = MyEntity.TBL1.Where(x => x.Id == id).Select(TBL1.Projection).SingleOrDefault();
vat tbl1 = tbl2.TBL1;
MyEntity.TB2.Add(tbl2);
MyEntity.TB1.Remove(tbl1);
MyEntity.SaveChanges();
