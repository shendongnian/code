`
    public class Calculator
    {
      public void Do(List<RuleBase> ruleList)
      {
        foreach ( var rule in ruleList )
        {
          rule.Calc();
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
      public RuleBase(int type, string name)
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
        return 1 + 2 + Type; // SAME
      }
      public Rule1()
        : base(1, "Rule1")
      {
      }
    }
`
`
    public class Rule2 : RuleBase
    {
      public override float Calc()
      {
        return 1 + 2 + Type; // SAME
      }
      public Rule2(int type, string name)
        : base(2, "Rule2")
      {
      }
    }
`
`
    public class Rule3 : RuleBase
    {
      public override float Calc()
      {
        return 3 + 4 + Type; // DIFFERENT
      }
      public Rule3(int type, string name)
        : base(3, "Rule3")
      {
      }
    }
`
