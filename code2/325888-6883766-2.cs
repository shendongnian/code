    using System;
    using System.Collections.Generic;
    using System.Reflection;
    
    public static class MyStaticClass
    {
        private static readonly object mapLock = new object();
        
        private static readonly Dictionary<Type, Action<object>>
            typeActionMap = new Dictionary<Type, Action<object>>();
        
        private static readonly MethodInfo helperMethod =
            typeof(MyStaticClass).GetMethod("ActionHelper",
                                            BindingFlags.Static |
                                            BindingFlags.NonPublic);
        
        public static void DoStuffDynamic(object item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            
            Type type = item.GetType();
            Action<object> action;
            lock (mapLock)
            {
                if (!typeActionMap.TryGetValue(type, out action))
                {
                    action = BuildAction(type);
                    typeActionMap[type] = action;
                }
            }
            action(item);
        }
        
        private static Action<object> BuildAction(Type type)
        {
            MethodInfo generic = helperMethod.MakeGenericMethod(type);
            Delegate d = Delegate.CreateDelegate(typeof(Action<object>),
                                                 generic);
            return (Action<object>) d;
        }
        
        private static void ActionHelper<T>(object item)
        {
            MyStaticClass<T>.DoStuff((T) item);
        }
    }
    
    
    public static class MyStaticClass<T>
    {
        public static void DoStuff(T something)
        {
            Console.WriteLine("DoStuff in MyStaticClass<{0}>",
                              typeof(T));
        }
    }
    
    public class Test
    {
        static void Main()
        {
            MyStaticClass.DoStuffDynamic("Hello");
            MyStaticClass.DoStuffDynamic(10);        
        }
    }
