        Type type = Type.GetTypeFromProgID("WinFax.Attachments");
        if (type == null)
              throw new ArgumentException("WinFax Pro is not installed.");
        Object comObject = Activator.CreateInstance(type);  
        Object o2 = type.InvokeMember("MethodReturnsLpdispatch",
                                         BindingFlags.InvokeMethod,
                                         null,
                                         comObject,
                                         null);
        Type t2 = Type.GetTypeFromProgID("WinFax.Attachment"); // different ProgId !!
        Object x = t2.InvokeMember("MethodOnSecondComObject",  
                                         BindingFlags.InvokeMethod,
                                         null,
                                         o2,
                                         null);
