    public static UrlHelperExtensions
    {
        public static string Action<TController>( Expression<Action<T>> action ) where TController : Controller
        {
            var routeValues = GetRouteValuesFromExpression( action ); 
            return Url.Action( routeValues["action"], routeValues );
        }
    
        // copied from MvcFutures
        // http://aspnet.codeplex.com/SourceControl/changeset/view/72551#266392
        private static RouteValueDictionary GetRouteValuesFromExpression<TController>(Expression<Action<TController>> action) where TController : Controller
        {
            if (action == null) {
                throw new ArgumentNullException("action");
            }
    
            MethodCallExpression call = action.Body as MethodCallExpression;
            if (call == null) {
                throw new ArgumentException(MvcResources.ExpressionHelper_MustBeMethodCall, "action");
            }
    
            string controllerName = typeof(TController).Name;
            if (!controllerName.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)) {
                throw new ArgumentException(MvcResources.ExpressionHelper_TargetMustEndInController, "action");
            }
            controllerName = controllerName.Substring(0, controllerName.Length - "Controller".Length);
            if (controllerName.Length == 0) {
                throw new ArgumentException(MvcResources.ExpressionHelper_CannotRouteToController, "action");
            }
    
            // TODO: How do we know that this method is even web callable?
            //      For now, we just let the call itself throw an exception.
    
            var rvd = new RouteValueDictionary();
            rvd.Add("Controller", controllerName);
            rvd.Add("Action", call.Method.Name);
            AddParameterValuesFromExpressionToDictionary(rvd, call);
            return rvd;
        }
    }
