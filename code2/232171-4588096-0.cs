    public interface ICanResetAndEnable
    {
        // Note: interfaces cannot have fields, only properties and methods.
        bool Enable { get; set; }
        void Reset();
    }
    
    public class Object1 : ICanResetAndEnable {
      bool Enable { get; set; }
      public void Reset(){
        Enable = false;
      }
    }
    
    public class Object2 : ICanResetAndEnable {
      bool Enable { get; set; }
      public void Reset(){
        Enable = false;
      }
    }
