using System;
using System.Reflection;
using System.Collections;
namespace TestApp
{
    public class TestClass
    {
        public string MyMethod(string param1, string param2)
        {
            return (param1 + param2);
        }
    }
    public class DynaInvoke
    {
        /// <summary>
        /// Method to invoke a method inside a class
        /// </summary>
        /// <param name="className">Name of a non static class</param>
        /// <param name="methodName">Name of a non static method</param>
        /// <param name="args">Parameters required for the method</param>
        /// <returns>result after execution of the method</returns>
        public object CommonMethod(string className, string methodName, object[] args)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            object result = InvokeMethodSlow(ass.Location, className, methodName, args);
            return result;
        }
        // this way of invoking a function
        // is slower when making multiple calls
        // because the assembly is being instantiated each time.
        // But this code is clearer as to what is going on
        public static Object InvokeMethodSlow(string AssemblyName,
               string ClassName, string MethodName, Object[] args)
        {
            // load the assemly
            Assembly assembly = Assembly.LoadFrom(AssemblyName);
            // Walk through each type in the assembly looking for our class
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass == true)
                {
                    if (type.FullName.EndsWith("." + ClassName))
                    {
                        // create an instance of the object
                        object ClassObj = Activator.CreateInstance(type);
                        // Dynamically Invoke the method
                        object Result = type.InvokeMember(MethodName,
                          BindingFlags.Default | BindingFlags.InvokeMethod,
                               null,
                               ClassObj,
                               args);
                        return (Result);
                    }
                }
            }
            throw (new System.Exception("could not invoke method"));
        }
        // ---------------------------------------------
        // now do it the efficient way
        // by holding references to the assembly
        // and class
        // this is an inner class which holds the class instance info
        public class DynaClassInfo
        {
            public Type type;
            public Object ClassObject;
            public DynaClassInfo()
            {
            }
            public DynaClassInfo(Type t, Object c)
            {
                type = t;
                ClassObject = c;
            }
        }
        public static Hashtable AssemblyReferences = new Hashtable();
        public static Hashtable ClassReferences = new Hashtable();
        public static DynaClassInfo
               GetClassReference(string AssemblyName, string ClassName)
        {
            if (ClassReferences.ContainsKey(AssemblyName) == false)
            {
                Assembly assembly;
                if (AssemblyReferences.ContainsKey(AssemblyName) == false)
                {
                    AssemblyReferences.Add(AssemblyName,
                          assembly = Assembly.LoadFrom(AssemblyName));
                }
                else
                    assembly = (Assembly)AssemblyReferences[AssemblyName];
                // Walk through each type in the assembly
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass == true)
                    {
                        // doing it this way means that you don't have
                        // to specify the full namespace and class (just the class)
                        if (type.FullName.EndsWith("." + ClassName))
                        {
                            DynaClassInfo ci = new DynaClassInfo(type,
                                               Activator.CreateInstance(type));
                            ClassReferences.Add(AssemblyName, ci);
                            return (ci);
                        }
                    }
                }
                throw (new System.Exception("could not instantiate class"));
            }
            return ((DynaClassInfo)ClassReferences[AssemblyName]);
        }
        public static Object InvokeMethod(DynaClassInfo ci,
                             string MethodName, Object[] args)
        {
            // Dynamically Invoke the method
            Object Result = ci.type.InvokeMember(MethodName,
              BindingFlags.Default | BindingFlags.InvokeMethod,
                   null,
                   ci.ClassObject,
                   args);
            return (Result);
        }
        // --- this is the method that you invoke ------------
        public static Object InvokeMethod(string AssemblyName,
               string ClassName, string MethodName, Object[] args)
        {
            DynaClassInfo ci = GetClassReference(AssemblyName, ClassName);
            return (InvokeMethod(ci, MethodName, args));
        }
    }
}
