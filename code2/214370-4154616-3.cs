    var assembly = System.Reflection.Assembly.GetExecutingAssembly();
    
    var methods = assembly.GetTypes()
                  .Where(t => t is System.Web.Mvc.Controller)
                  .SelectMany(t => t.GetMethods())
                  .Where(m => m.ReturnType is ActionResult)
                  .Where(m => m.GetCustomAttributes(typeof(TargetAttribute), false).Length > 0)
                  .ToArray();
    
    bool implementsITarget = false;
    
    foreach(method in methods)
    {
        foreach(param in method.GetParameters())
        {
            if(param.ParameterType is ITarget) 
            {
                implementsITarget = true;
                break;
            }
        }
        Assert.True(implementsITarget , String.Format(Controller {0} has action {1} that does not implement ITarget but is decorated with TargetAttribute, method.DeclaringType, method.Name) );
        implementsITarget = false;
    }
