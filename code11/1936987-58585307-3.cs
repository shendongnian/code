methods = _theApplicationType.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
foreach (MethodInfo m in methods) {
    if (ReflectOnMethodInfoIfItLooksLikeEventHandler(m))
        handlers.Add(m);
}
Then the method is invoked on HttpApplication object, since the method is now static the first param should be ignored and the static method should be called. 
if (paramCount == 0) {
   method.Invoke(this, new Object[0]);
}
###Why 404 / 403?
Application_Start is, by convention the place where [routes are configured](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/lifecycle-of-an-aspnet-mvc-5-application/_static/lifecycle-of-an-aspnet-mvc-5-application1.pdf).
## My toy app 
I put together a toy up to eliminate anything obvious. The method is called.
using System;
using System.Reflection;
using System.Web;
namespace NETFrameworkConsoleApp2
{
    public class MyHttpApp : HttpApplication
    {
        protected static void Application_Start()
        {
            Console.WriteLine("Very important work");
        }
    }
    class Program
    {
        private MethodInfo _onStartMethod;        // Application_OnStart
        public static void Main()
        {
            //Flags from https://referencesource.microsoft.com/#System.Web/HttpApplicationFactory.cs,74e5273062f54e5f,references
            var methods = typeof(MyHttpApp).GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            var a = new MyHttpApp();
            var p = new Program();
            foreach (MethodInfo m in methods)
            {
                p.ReflectOnMethodInfoIfItLooksLikeEventHandler(m);
            }
            p._onStartMethod.Invoke(a, new Object[0]);
            Console.ReadLine();
        }
        private bool ReflectOnMethodInfoIfItLooksLikeEventHandler(MethodInfo m)
        {
            // From https://referencesource.microsoft.com/#System.Web/HttpApplicationFactory.cs,b0a90d9df37ace19,references
            if (m.ReturnType != typeof(void))
                return false;
            // has to have either no args or two args (object, eventargs)
            ParameterInfo[] parameters = m.GetParameters();
            switch (parameters.Length)
            {
                case 0:
                    // ok
                    break;
                case 2:
                    // param 0 must be object
                    if (parameters[0].ParameterType != typeof(System.Object))
                        return false;
                    // param 1 must be eventargs
                    if (parameters[1].ParameterType != typeof(System.EventArgs) &&
                        !parameters[1].ParameterType.IsSubclassOf(typeof(System.EventArgs)))
                        return false;
                    // ok
                    break;
                default:
                    return false;
            }
            // check the name (has to have _ not as first or last char)
            String name = m.Name;
            int j = name.IndexOf('_');
            if (j <= 0 || j > name.Length - 1)
                return false;
            // special pseudo-events
            if (StringUtil.EqualsIgnoreCase(name, "Application_OnStart") ||
                StringUtil.EqualsIgnoreCase(name, "Application_Start"))
            {
                _onStartMethod = m;
                //_onStartParamCount = parameters.Length;
            }
            else if (StringUtil.EqualsIgnoreCase(name, "Application_OnEnd") ||
                     StringUtil.EqualsIgnoreCase(name, "Application_End"))
            {
                //_onEndMethod = m;
                //_onEndParamCount = parameters.Length;
            }
            else if (StringUtil.EqualsIgnoreCase(name, "Session_OnEnd") ||
                     StringUtil.EqualsIgnoreCase(name, "Session_End"))
            {
                //_sessionOnEndMethod = m;
                //_sessionOnEndParamCount = parameters.Length;
            }
            return true;
        }
        internal static class StringUtil
        {
            //From https://referencesource.microsoft.com/#System.Web/Util/StringUtil.cs,d3a0b2a26cb3f1e1
            internal static bool EqualsIgnoreCase(string s1, string s2)
            {
                if (String.IsNullOrEmpty(s1) && String.IsNullOrEmpty(s2))
                {
                    return true;
                }
                if (String.IsNullOrEmpty(s1) || String.IsNullOrEmpty(s2))
                {
                    return false;
                }
                if (s2.Length != s1.Length)
                {
                    return false;
                }
                return 0 == string.Compare(s1, 0, s2, 0, s2.Length, StringComparison.OrdinalIgnoreCase);
            }
        }
        static Program() => Console.WriteLine(GetFrameworkName());
        static string GetFrameworkName()
            => ((System.Runtime.Versioning.TargetFrameworkAttribute)
                    (System.Reflection.Assembly.GetEntryAssembly()
                    .GetCustomAttributes(typeof(System.Runtime.Versioning.TargetFrameworkAttribute), true)[0]))
                    .FrameworkName; // Example: .NETCoreApp,Version=v3.0
    }
}
