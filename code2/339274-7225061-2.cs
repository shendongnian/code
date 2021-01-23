    if (invocation.Method.DeclaringType.Equals(typeof(IDataErrorInfo)))
    {
        if (invocation.Method.Name.Equals("get_Item"))
        {
            // some code
        }
        else if (invocation.Method.Name.Equals("get_Error"))
        {
            // more code
        }
        else
        {
            invocation.Proceed();
        }
    }
