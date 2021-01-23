    interface IStrategy
    {
      void Operation1(int x, int y);
      void Operation2(string a, string b);
    }
    
    class ClassA : IStrategy
    {
      private IStrategy builtInStrategy = new BuiltInStrategy();
      
      public IStrategy CustomStrategy { get; set; }
    
      void Operation1(int x, int y);
      {
        if (CustomStrategy != null)
        {
          CustomStrategy.Operation1(x, y);
        }
        else
        {
          builtInStrategy.Operation1(x, y);
        }
      }
    
      void Operation2(string a, string b)
      {
        if (CustomStrategy != null)
        {
          CustomStrategy.Operation2(a, b);
        }
        else
        {
          builtInStrategy.Operation2(a, b);
        }
      }
    }
