    abstract class AConfigAction { }
    
    interface APlugin<out ConfigActionType> where ConfigActionType : AConfigAction { }
    
    class AppExecuteConfigAction : AConfigAction { }
    
    class AppExecutePlugin : APlugin<AppExecuteConfigAction> { }
    
    class Program
    {
        public static void Main()
        {
            var _plugins = new List<APlugin<AConfigAction>>();
            _plugins.Add(new AppExecutePlugin());
        }
    }
