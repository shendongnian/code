    public interface IDoSomething {
      void Method();
    }
    public class ConditionallyDoSomething : IDoSomething {
      private IDoSomething _wrapped;
  
      public ConditionallyDoSomething(IDoSomething wrapped) {
        _wrapped = wrapped;
      }
  
      public bool IsMethodEnabled { get; set; } // could be quite complex...
      public void Method() {
        if (IsMethodEnabled) {
          _wrapped.Method();
        }
      }
    }
    public class DoSomething : IDoSomething {
      public void Method() {
        // do something...
      }
    }
