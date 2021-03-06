    var assembly = System.Reflection.Assembly.GetExecutingAssembly();
    
    var methods = assembly.GetTypes()
                  .Where(t => t.Name.Contains(CONTROLLER))
                  .Where(t => !t.IsAbstract)
                  .SelectMany(t => t.GetMethods())
                  .Where(m => (m.ReturnType as ActionResult) != null)
                  .Where(m => m.GetCustomAttributes(typeof(TargetAttribute), false).Length > 0)
                  .ToArray();
    
    bool implementsITarget = false;
    
    foreach(method in methods)
    {
        foreach(param in method.GetParameters())
        {
            if((param as ITarget) != null) 
            {
                implementsITarget = true;
                break;
            }
        }
        Assert.True(implementsITarget , String.Format(Controller {0} has action {1} that does not implement ITarget but is decorated with TargetAttribute, method.DeclaringType, method.Name) );
        implementsITarget = false;
    }
