    Action<string> s;
    Action<object> o;
               
    object sTarget = s.Target;
    object oTarget = o.Target;
    
    MethodInfo sMethod = s.Method;
    MethodInfo oMethod = o.Method;
    
    // Time to invoke in a later time.
    sMethod.Invoke(sTarget, new object[] { strVal });
    oMethod.Invoke(oTarget, new object[] { objVal });
