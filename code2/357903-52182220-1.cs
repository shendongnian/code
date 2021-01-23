    namespace NetStandardReporting
    {
        
    
        // [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
        public class DynamicDllImportAttribute
            : System.Attribute
        {
            protected string m_name;
    
    
            public string Name
            {
                get
                {
                    return this.m_name;
                }
            }
    
    
            public DynamicDllImportAttribute(string name)
                : base()
            {
                this.m_name = name;
            }
    
    
            private static System.Type CreateDelegateType(System.Reflection.MethodInfo methodInfo)
            {
                System.Func<System.Type[], System.Type> getType;
                bool isAction = methodInfo.ReturnType.Equals((typeof(void)));
    
                System.Reflection.ParameterInfo[] pis = methodInfo.GetParameters();
                System.Type[] types = new System.Type[pis.Length + (isAction ? 0: 1)];
    
                for (int i = 0; i < pis.Length; ++i)
                {
                    types[i] = pis[i].ParameterType;
                }
    
                if (isAction)
                {
                    getType = System.Linq.Expressions.Expression.GetActionType;
                }
                else
                {
                    getType = System.Linq.Expressions.Expression.GetFuncType;
                    types[pis.Length] = methodInfo.ReturnType;
                }
    
                return getType(types);
            }
    
    
            private static System.Delegate CreateDelegate(System.Reflection.MethodInfo methodInfo, object target)
            {
                System.Type tDelegate = CreateDelegateType(methodInfo);
    
                if(target != null)
                    return System.Delegate.CreateDelegate(tDelegate, target, methodInfo.Name);
    
                return System.Delegate.CreateDelegate(tDelegate, methodInfo);
            }
    
    
            // protected delegate string getName_t();
    
            public DynamicDllImportAttribute(System.Type classType, string delegateName)
                : base()
            {
                System.Reflection.MethodInfo mi = classType.GetMethod(delegateName,
                      System.Reflection.BindingFlags.Static
                    | System.Reflection.BindingFlags.Public
                    | System.Reflection.BindingFlags.NonPublic
                );
    
                // getName_t getName = (getName_t)System.Delegate.CreateDelegate(delegateType, mi));
                System.Delegate getName = CreateDelegate(mi, null);
                
                object name = getName.DynamicInvoke(null);
                this.m_name = System.Convert.ToString(name);
            }
    
        } // End Class DynamicDllImportAttribute 
    
    
        public class DynamicDllImportTest 
        {
    
            private static string GetFreetypeName()
            {
                if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
                    return "libfreetype.so.6";
    
                return "freetype6.dll";
            }
    
    
            // [DynamicDllImportAttribute("freetype6")]
            [DynamicDllImportAttribute(typeof(DynamicDllImportTest), "GetFreetypeName")]
            public static string bar()
            {
                return "foobar";
            }
    
    
            // NetStandardReporting.DynamicDllImportTest.Test();
            public static void Test()
            {
                System.Reflection.MethodInfo mi = typeof(DynamicDllImportTest).GetMethod("bar",
                      System.Reflection.BindingFlags.Static
                    | System.Reflection.BindingFlags.Public
                    | System.Reflection.BindingFlags.NonPublic);
    
                object[] attrs = mi.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    DynamicDllImportAttribute importAttr = attr as DynamicDllImportAttribute;
                    if (importAttr != null)
                    {
                        System.Console.WriteLine(importAttr.Name);
                    }
                } // Next attr 
    
            } // End Sub Test 
    
    
        } // End Class 
    
    
    } // End Namespace 
