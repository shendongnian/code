    public static Object ExecuteBLMethod(string ClassName, string Method, object[] args)
        {
            Type _Class = Type.GetType("BusinessLayer." + ClassName + ", BL, Version=1.0.0.0, Culture=neutral, PublicKeyToken="xxxx-xx");
            if (_Class != null)
            {
                object obj = Activator.CreateInstance(_Class);
                if (obj != null)
                    return _Class.InvokeMember(Method, BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, args);
            }
            return null;
        }
