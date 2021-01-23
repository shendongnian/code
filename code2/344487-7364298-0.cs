    public class Rule
    {
       public string Description {get; set;}
       public Func<T, bool> RuleToApply {get; set;}
    }
