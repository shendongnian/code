    using Parent;
    using System;
    using System.Reflection;
    
    namespace Parent
    {
        public interface ILoader
        {
    
            int ExecuteAssm(int arg1, int arg2);
            byte[] Test();
        }
    
        public class Loader : MarshalByRefObject, ILoader
        {
            Assembly test1 = null;
            byte[] test;
            public byte[] Test()
            {
                byte[] test = System.IO.File.ReadAllBytes("C:\\Users\\username\\source\\repos\\Test\\Test\\bin\\Debug\\Test.dll");
                return test;
            }
            public int ExecuteAssm(int arg1, int arg2)
            {
                
                if (test1 == null)
                {
                    test = Test();
                    test1 = Assembly.Load(test);
                }
                
                foreach (Type type in test1.GetTypes())
    
                    if (type.ToString().ToUpper() == "PROGRAM")
                    {
                        MethodInfo method = type.GetMethod("math");
                        object o = test1.CreateInstance("math");
                        var returnint = method.Invoke(o, new object[] { arg1, arg2 });
                        Console.WriteLine(method);
                        Console.WriteLine(returnint);
                        return (int)returnint;
                    }
                return 0;
            }
        }
            //Type t = test1.GetType("Test.Class1");
    
            //var methodInfo = t.GetMethod("math", new Type[] { typeof(int), typeof(int) });
            //var o = Activator.CreateInstance(t);
            //var result = MethodInfo.(o, new Type[] { 32, 32 });
    
    
        }
    
    class Program
    {
        static void Main(string[] args)
        {
    
            var domain = AppDomain.CreateDomain("child");
            var loader = (ILoader)domain.CreateInstanceAndUnwrap(typeof(Loader).Assembly.FullName, typeof(Loader).FullName);
            loader.ExecuteAssm(32, 32);
            loader.ExecuteAssm(2, 2);
            AppDomain.Unload(domain);
            // int returnint = ILoader.ExecuteAssm(32, 32);
            //Console.WriteLine(returnint);
        }
    }
