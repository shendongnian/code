    [Flags]
    public enum CVarAccessibilities
    {
         Settable,
         Gettable
    }
    public class CVar<T>
    {
         public CVarAccessibilities Accessibility { get; set; }
         T val;
         public T Value { 
            get { return val; }
            set
            {
                 if (!Accessibility.HasFlag(CVarAccessibilities.Settable))
                      return; // just don't set it, maybe print some warning
                 val = value;
            }
         }
    }
    public static class CVarRegistry
    {
         static Dictionary<string, Object> CVars;
         static CVarRegistry { /* use reflections to initialize the dictionary */ }
         public static T GetValue<T>(Type owner, string paramName)
         {
              CVar cvar;
              if (!CVars.TryGetValue(owner.Name + "_" + paramName, out cvar)
                     throw new MyCustomException();
              return (T)cvar.Value;
         }
         public static void SetValue<T>(Type owner, string paramName, T value)
         {
              CVar cvar;
              if (!CVars.TryGetValue(owner.Name + "_" + paramName, out cvar)
                     throw new MyCustomException();
              cvar.Value = value;
         }
    }
    public class MyObject
    {
        public static int MyRegisteredValue
        {
            get { return Global.CVarRegistry.GetValue<int>(typeof(MyObject), "MyRegisteredValue");  }
            set { Global.CVarRegistry.SetValue(typeof(MyObject), "MyRegisteredValue"); }
        }
     }
