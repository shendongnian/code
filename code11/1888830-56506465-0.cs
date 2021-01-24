    public abstract class BasePlugin : IPlugin {
      protected abstract DoExecute(IServiceProvider serviceProvider);
      public void Execute(IServiceProvider serviceProvider) {
        try { 
          this.DoExecute(serviceProvider); 
        } catch (Exception e) {
          throw new InvalidPluginExecutionException(e.ToString());
        }
      }
    }
