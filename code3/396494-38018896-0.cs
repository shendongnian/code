        using System.Reflection;
        ...
        public static void FireEvent(this object onMe, string invokeMe, params object[] eventParams)
        {
            TypeInfo typeInfo = onMe.GetType().GetTypeInfo();
            FieldInfo fieldInfo = typeInfo.GetDeclaredField(invokeMe);
            MulticastDelegate eventDelagate = (MulticastDelegate)fieldInfo.GetValue(onMe);
            Delegate[] delegates = eventDelagate.GetInvocationList();
            foreach (Delegate dlg in delegates)
            {
                dlg.GetMethodInfo().Invoke(dlg.Target, eventParams);
            }
        }
