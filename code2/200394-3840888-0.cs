    public class ControllerConvention : TypeRules, ITypeScanner {
      public void Process(Type type, PluginGraph graph) {
         if (CanBeCast(typeof (IController), type)) {
         string name = type.Name.Replace("Controller", "").ToLower();
          graph.AddType(typeof(IController), type, name);
        }
      }
    }
