    //Assembly1.dll
    using System;
    using System.Reflection;
    
    namespace TestAssembly
    {
        public class Main
        {
            public void Run(string parameters)
            {
                // Do something... 
            }
            public void TestNoParameters()
            {
                // Do something... 
            }
        }
    }
    
    //Executing Assembly.exe
    public class TestReflection
    {
        public void Test(string methodName)
        {
            Assembly assembly = Assembly.LoadFile("...Assembly1.dll");
            Type type = assembly.GetType("TestAssembly.Main");
            if (type != null)
            {
                MethodInfo methodInfo = type.GetMethod(methodName);
                if (methodInfo != null)
                {
                    object result = null;
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    object classInstance = Activator.CreateInstance(type, null);
                    if (parameters.Length == 0)
                    {
                        result = methodInfo.Invoke(classInstance, null);
                    }
                    else
                    {
                        object[] parametersArray = new object[] { "Hello" };
             
                        result = methodInfo.Invoke(classInstance, parametersArray);
                    }
                }
            }
        }
    }
