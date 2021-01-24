public enum Foo
{
  One = 1,
  Two = 2,
  Four = 4,
  Eight = 8
}
var state1 = Foo.One;
var state2 = Foo.Two;//
var state3 = Foo.One | Foo.Two; 
var state4 = Foo.Two | Foo.Four;
Console.WriteLine(MoreThanOneFlag(state1));//false
Console.WriteLine(MoreThanOneFlag(state2));//false
Console.WriteLine(MoreThanOneFlag(state3));//true
Console.WriteLine(MoreThanOneFlag(state4));// true
private static bool MoreThanOneFlag<TEnum>(TEnum state) where TEnum : Enum
{
  var names = Enum.GetValues(typeof(TEnum));
  var Flagcounter = names.OfType<TEnum>().Where(x=>state.HasFlag((TEnum)x)).Count();
  return Flagcounter > 1 ? true : false;
}
