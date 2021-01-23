    public static void FirePublicEvent(object onMe, string invokeMe, params object[] eventParams)
    {
        MulticastDelegate eventDelagate =
              (MulticastDelegate)onMe.GetType().GetField(invokeMe,
               System.Reflection.BindingFlags.Instance |
               System.Reflection.BindingFlags.Public).GetValue(onMe);
        Delegate[] delegates = eventDelagate.GetInvocationList();
        foreach (Delegate dlg in delegates)
        {
           dlg.Method.Invoke(dlg.Target, eventParams);
        }
    } 
