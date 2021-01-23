    // [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public class MyAttribute 
        : System.Attribute
    {
        protected string m_name;
        public string Name
        {
            get {
                return this.m_name;
            }
        }
        public MyAttribute(string name)
            :base()
        {
            this.m_name = name;
        }
        private static System.Type CreateDelegateType(System.Reflection.MethodInfo methodInfo)
        {
            Func<Type[], Type> getType;
            var isAction = methodInfo.ReturnType.Equals((typeof(void)));
            var types = methodInfo.GetParameters().Select(p => p.ParameterType);
            if (isAction)
            {
                getType = System.Linq.Expressions.Expression.GetActionType;
            }
            else
            {
                getType = System.Linq.Expressions.Expression.GetFuncType;
                types = types.Concat(new[] { methodInfo.ReturnType });
            }
            return getType(types.ToArray());
        }
        private static Delegate CreateDelegate(System.Reflection.MethodInfo methodInfo, object target)
        {
            System.Type tDelegate = CreateDelegateType(methodInfo);
            return Delegate.CreateDelegate(tDelegate, target, methodInfo.Name);
        }
        // protected delegate string getName_t();
        public MyAttribute(System.Type classType, string delegateName)
            : base()
        {
            System.Reflection.MethodInfo mi = classType.GetMethod(delegateName,
                  System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic
            );
            System.Type delegateType = CreateDelegateType(mi);
            // getName_t getName = (getName_t)System.Delegate.CreateDelegate(delegateType, mi));
            System.Delegate getName = System.Delegate.CreateDelegate(delegateType, mi);
            object name = getName.DynamicInvoke(null);
            this.m_name = System.Convert.ToString(name);
        }
    }
    
    public class Program
    {
        public static string GetFreetypeName()
        {
            if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
                return "libfreetype.so.6";
            return "freetype6.dll";
        }
        // [My("freetype6")]
        [MyAttribute(typeof(Program), "GetFreetypeName")]
        public static string bar()
        {
            return "abc";
        }
        public static void Main(string[] args)
        {
            System.Reflection.MethodInfo mi = typeof(Program).GetMethod("bar",
                  System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic);
            object[] attrs = mi.GetCustomAttributes(true);
            foreach (object attr in attrs)
            {
                MyAttribute authAttr = attr as MyAttribute;
                if (authAttr != null)
                {
                    System.Console.WriteLine(authAttr.Name);
                }
            }
        }
    }
