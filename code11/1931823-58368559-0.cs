    public abstract class BaseClass {
      protected BaseClass(BaseClass Source, var changes...) ...
    }
    
    public class DerivedClass {
      private DerivedClass(DerivedClass Source, var changes)
        : BaseClass(Source, changes) { }
    
    public DerivedClass MakeChange(var change) {
      ...set up changed values...
      return new DerivedClass(this, changes)
      }
    }
