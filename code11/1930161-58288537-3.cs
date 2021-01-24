`
class Calculator
{
  public void Do(List<RuleBase> ruleList)
  {
    foreach ( var rule in ruleList )
    {
      // do what you want with the result of rule.Calc();
    }
  }
}
`
`
public abstract class RuleBase
{
  public int Type { get; private set; }
  public string Name { get; private set; }
  public abstract float Calc();
  protected RuleBase(int type, string name)
  {
    Type = type;
    Name = name;
  }
}
`
`
public class Rule1 : RuleBase
{
  public override float Calc()
  {
    return 1 + 2 + Type;
  }
  public Rule1()
    : base(1, "Rule1")
  {
  }
  protected Rule1(int type, string name)
    : base(type, name)
  {
  }
}
`
`
public class Rule2 : Rule1
{
  public Rule2()
    : base(2, "Rule2")
  {
  }
  protected Rule2(int type, string name)
    : base(type, name)
  {
  }
}
`
`
public class Rule3 : RuleBase
{
  public override float Calc()
  {
    return 3 + 4 + Type;
  }
  public Rule3()
    : base(3, "Rule3")
  {
  }
  protected Rule3(int type, string name)
    : base(type, name)
  {
  }
}
`
