    public class Foo
    {
      private string instanceVariable;
    
    
      public void Set(string s)
      {
        instanceVariable = s;
      }
      public string Get()
      {
        return instanceVariable; //same value as "s" in "Set"
      }
    }
