    using System;
    using System.Data;
    using PostSharp.Aspects;
    
    namespace TestAOP
    {
        class Program
        {
            static void Main(string[] args)
            {
                var someInstance = new SomeClass();
                someInstance.test(null, null, null, null);
            }
        }
    
    
        public class SomeClass
        {
            [CheckForNulls]
            public void test(string arg1, string arg2, object arg3, DataTable arg4)
            {           
                // do the rest...
            }
        }
        [Serializable]
        public class CheckForNullsAttribute : OnMethodBoundaryAspect
        {
            public override void OnEntry(MethodExecutionArgs args)
            {
                var parameters = args.Method.GetParameters();            
                for (int i = 0; i < args.Arguments.Count; i++)
                {
                    if (args.Arguments[i] == null)
                        throw new ArgumentNullException(parameters[i].Name);
                }
            }
        }
    }
