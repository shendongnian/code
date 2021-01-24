class Bar
{
  public string BarType {get; protected set};
  public Bar(string barType)
  {
    BarType = barType;
  }
}
public class FooMap : ClassMap<Foo>
{
  Table("Foo");
  Id(x => x.Id);
  HasMany(x => x.TheoreticalBar).Where("BarType = theoretical");
  HasMany(x => x.ActualBar).Where("BarType = actual"); 
}
The .Where() method allows use of string interpolation and substitutions in case you want to avoid magic strings in my simplistic example here.  
