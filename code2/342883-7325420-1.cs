        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using PostSharp.Aspects;
        using System.Diagnostics;
        
        [assembly: ConsoleApplication2.TraceIntercept(AttributeTargetAssemblies = "System", AttributeTargetTypes = "System.Diagnostics.Trace")]
        
        namespace ConsoleApplication2
        {
            class Program
            {
                static void Main(string[] args)
                {
                    ExampleA ex = new ExampleA();
                    ex.Method1();
        
                    Console.ReadKey();
                }
        
            }
        
            public class ExampleA
            {
                public void Method1()
                {
                    Trace.Write("Test");
                }
        
            }
        
    [Serializable]
        [TraceIntercept(AttributeExclude = true)]
        public class TraceIntercept : MethodInterceptionAspect
        {
            private bool addArgument;
            private string typeName = string.Empty;
    
            public override void OnInvoke(MethodInterceptionArgs args)
            {
                CheckInvocationPoint();
    
                if (addArgument)
                {
                    //Do work. Change arguments, etc.
                }
    
                args.Proceed(); // Proceed with Trace
            }
    
            private void CheckInvocationPoint()
            {
                if (string.IsNullOrEmpty(this.typeName))
                {
                    StackTrace s = new StackTrace();
                    StackFrame f = s.GetFrame(2);
                    string className = f.GetMethod().DeclaringType.Name;
    
                    if (classsName.Equals("ExampleA"))
                    {
                        addArgument = true;
                    }
                }
            }
        }
    }
