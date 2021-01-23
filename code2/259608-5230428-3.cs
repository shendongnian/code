    public class MyType<T>
    {
       public void TryParse(string p_value)
       {
          T value = default(T);
          // search for the method using reflection
          System.Reflection.MethodInfo methodInfo = typeof(Parser).GetMethod
             (
                "TryParse",
                new System.Type[] { typeof(string), typeof(T).MakeByRefType() }
             );
          if (methodInfo != null)
          {
             // the method does exist, so we can now call it
             var parameters = new object[] { p_value, value };
             methodInfo.Invoke(null, parameters);
             value = (T)parameters[1];
          }
          else
          {
             // The method does not exist. Handle that case
          }
       }
    }
