    public interface IActionable 
    {
      public ActionType Action { get; }
    }
    public class ActionableWrapper : IActionable
    { 
      private ActionType _action;
      public ActionableWrapper(IActionable Actionable)
      {
        this._action = Actionable;
      }
      new public ActionType Action 
      { 
        get { return _action; } 
      } 
    } 
    public class BlueAction: IActionable
    {
      public ActionType Action { get; }
    }
