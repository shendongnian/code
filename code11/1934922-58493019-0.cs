public class Mallard
{
   public readonly Duck duck;
   public Mallard(Duck d)
   {
      duck = d;
   }
}
If you're just looking to add new functionality to a Duck, but can't change it, you can use extension methods.
public static class DuckExtensions
{
   public IEnumerable<Wing> CookWings(this Duck duck) { ... }
}
