    public class Definition 
    {
    
      private String _name;
      private Rule _rule;
    
      public Definition(String name) {
        _name = name;
      }
    
      public static Definition Name(String name) {
        return new Definition(name);
      }
    
      public Definition SetRule(Rule rule) {
        _rule = rule;
        return this;
      }
    	
      // Works like a charm
      public Definition SetRule(Func<Data, DataType, Boolean> func) {
        _rule = new Rule(func);
        return this;
      }
    
      public bool Run(Data data, DataType dataType) {
         return _rule.IsSatisfied(data, dataType);
      }
    }
    
