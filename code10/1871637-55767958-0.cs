    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    
    namespace Zero
    {
        [AttributeUsage(AttributeTargets.Method)]
        public class MethodGetterAttribute : ExportAttribute { }
    
        public class Person { }
    
        public class Worker : Person { }
    
        public static class MethodHelper
        {
            public static string GetMethod()
            {
                var method = new StackTrace().GetFrame(1).GetMethod();
                return $"{method.DeclaringType.FullName} {method}";
            }
        }
    
        public static class Discovery
        {
            public static TDelegate[] GetDelegates<TAttribure, TDelegate>()
                where TAttribure : Attribute
                where TDelegate : Delegate
            {
                return Directory.GetFiles(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "*.dll")
                                .Select(file => { try { return Assembly.LoadFrom(file); } catch { return null; } })
                                .OfType<Assembly>()
                                .Append(Assembly.GetEntryAssembly())
                                .SelectMany(assembly => assembly.GetTypes())
                                .SelectMany(type => type.GetMethods())
                                .Where(method => method.GetCustomAttributes(typeof(TAttribure)).Any())
                                .Select(method => Delegate.CreateDelegate(typeof(TDelegate), null, method, false))
                                .OfType<TDelegate>()
                                .ToArray();
            }
        }
    }
