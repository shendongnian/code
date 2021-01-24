csharp
public abstract class TypeAlias
  {
    public virtual object ValueAsObject { get; set; }
    public virtual Type PresentingType { get; set; }
  }
  public class TypeAlias<T> : TypeAlias
    where T : class
  {
    private T underlyingTypeSafeObject;
    public TypeAlias()
      : base()
    {
      base.PresentingType = typeof(T);
    }
    public T TypeSafeObject
    {
      get
      {
        return this.underlyingTypeSafeObject;
      }
      set
      {
        this.underlyingTypeSafeObject = value;
        if (base.PresentingType == null && value != null)
        {
          base.PresentingType = value.GetType();
        }
      }
    }
    public override object ValueAsObject
    {
      get
      {
        return this.underlyingTypeSafeObject;
      }
      set
      {
        // returns null if cast conversion fails - not type-safe on the TypeAlias level.
        this.underlyingTypeSafeObject = value as T;
      }
    }
    public override Type PresentingType
    {
      get => base.PresentingType; set => base.PresentingType = value;
    }
}
With that convention, and with the following interfaces (and implementations) in mind:
csharp
  public interface IOrganism
  {
    string Be();
  }
  public interface IDomain : IOrganism
  {
    string DomainName { get; set; }
  }
  public interface IKingdom : IDomain, IOrganism
  {
    string KingdomName { get; set; }
  }
  public class SeventhDimension : IDomain
  {
    private string domainName = "7th Dimension";
    string IDomain.DomainName { get => domainName; set => domainName = value; }
    public virtual string Be()
    {
      return string.Format("{0} Exists.", this.domainName);
    }
  }
  public class KingdomHyrule : SeventhDimension, IKingdom, IDomain
  {
    private string kingdomName = "Hyrule";
    string IKingdom.KingdomName { get => kingdomName; set => kingdomName = value; }
    public virtual string Be()
    {
      string s = base.Be();
      s += string.Format(" Also, {0} Exists.", this.kingdomName);
      return s;
    }
  }
We can now have the following code to provide a different alias, which we can control the presentation of, to allow for reflection on differing degrees upon the inherited pedigree of any particular implementation of an object:
csharp
// Create a Hyrule Kingdom, which is also a SeventhDomain,
// and IOrganism, IKingdom, IDomain.
IOrganism testOrganism = new KingdomHyrule();
Console.WriteLine(testOrganism.Be());
// Construct a TypeAlias, which by default presents
// the type of the container you store it as,
// using Generics.
TypeAlias alias = new TypeAlias<SeventhDimension>()
{
  ValueAsObject = testOrganism
};
Console.WriteLine();
// Grab the real type of the testOrganism,
// which will be KingdomHyrule
Console.WriteLine(testOrganism.GetType().Name);
// Grab the faked type of testOrganism,
// which will be SeventhDimension, due to
// the construction of the Alias.
Console.WriteLine(alias.PresentingType.Name);
// Could be retrieved using reflection on Implementing Types
alias.PresentingType = typeof(IOrganism);
Console.WriteLine(alias.PresentingType.Name);
/* Output:
* 7th Dimension Exists. Also, Hyrule Exists. | from testOrganism.Be();
*
* KingdomHyrule | from testOrganism.GetType().Name;
* SeventhDimension | from alias.PresentingType.Name;
* IOrganism | from alias.PresentingType.Name, after assignment
* */
As I said above - I no longer even need this, but the classes TypeAlias and `TypeAlias<T>` make it easy to loosely couple an arbitrary instance of a class, and have it present any other type (which by convention could be used to allow you to use reflection to grab properties / methods out of reflectively detected base types).
