       public static T SafeParseAndAssign<T>(string val) where T: new()
        {
            try
            {
                T ValOut = new T();
                MethodInfo MI = ValOut.GetType().
                  GetMethod("Parse", new Type[] { val.GetType() });
                return (T)MI.Invoke(ValOut, new object[] { val });
            }
            catch
            {
                // swallow exception
            }
            return default(T);
        }
