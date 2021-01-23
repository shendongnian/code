    public class ActionWithResult<T> : ActionBase { 
      public Func<T> Action { get; set; } 
    }
 
    public class ActionWithoutResult : ActionBase {
      public Action Action { get; set; }
    }
