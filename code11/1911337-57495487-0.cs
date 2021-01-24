    [CheckRole]
    public HttpResponseMessage GetUser()
    {
        if(Engine.Method2()) throw new Exception();
    
        return ReturnSeccess200();
    }
    
    
    public class CheckRoleAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
             if(Engine.Method1()) throw new Exception();
        }
    }
    
    
    public class Engine
    {
        public static bool Method1(){ return true; }
        public static  bool Method2(){ return true; }
    }
