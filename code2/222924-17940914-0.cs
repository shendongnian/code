    var actionName = filterContext.RouteData.Values["action"].ToString();
    var ctlr = filterContext.Controller as Controller;
    if (ctlr == null) return;
    var invoker = ctlr.ActionInvoker as ControllerActionInvoker;
    if (invoker == null) return;
    var invokerType = invoker.GetType();
    var getCtlrDescMethod = invokerType.GetMethod("GetControllerDescriptor", BindingFlags.NonPublic | BindingFlags.Instance);
    var ctlrDesc = getCtlrDescMethod.Invoke(invoker, new object[] {ctlr.ControllerContext}) as ControllerDescriptor;
    var findActionMethod = invokerType.GetMethod("FindAction", BindingFlags.NonPublic | BindingFlags.Instance);
    var actionDesc = findActionMethod.Invoke(invoker, new object[] { ctlr.ControllerContext, ctlrDesc, actionName }) as ReflectedActionDescriptor;
    if (actionDesc == null) return;
    if (actionDesc.MethodInfo.ReturnType == typeof (ActionResult))
    {
        // you're in
    }
}
