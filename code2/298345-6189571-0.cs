    public struct MyStruct
    { ... };
    public class MyInvokedClass
    {
        public MyStruct InvokedMethod()
        { 
            MyStruct structure;
            ... 
            return structure; 
        }
    }
    
    public class MyInvokingClass
    {
        static void Main(string[] args)
        { 
            ...
            MethodInfo methodInfo = classType.GetMethod(methodName);
            MyStruct result = (MyStruct)methodInfo.Invoke(classInstance, null); 
        }
    }
