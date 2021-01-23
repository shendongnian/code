    public abstract class RuleBase
    {
      public abstract bool Test();
      public virtual bool CanCorrect()
      { 
         return false;
      }
    }
