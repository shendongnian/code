    public abstract class ActionResult : IActionResult
    {
      public virtual Task ExecuteResultAsync(ActionContext context)
      {
       this.ExecuteResult(context);
       return Task.CompletedTask;
      }
      public virtual void ExecuteResult(ActionContext context)
      {
      }
    }
