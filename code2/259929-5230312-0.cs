public abstract class AProductBase&lt;T&gt;
{
  public IDictionary&lt;string, T&gt; PriceList { get; set; }
  ...
}
public class Product : AProductBase&lt;decimal&gt;
{
  ...
}
public enum PriceTypeEnum { ... }
public class SpecialProduct : AProductBase&lt;IDictionary&lt;PriceTypeEnum, decimal&gt;&gt;
{
  ...
}
