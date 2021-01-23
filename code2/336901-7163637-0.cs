    namespace ConsoleApplication12
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyExampleClass ec = new MyExampleClass();
                ec.MyMethod();
            }
        }
    
        public class MyExampleClass
        {
            [Special(Key = "test1", Value = "1234")]
            [Special(Key = "test2", Value = "4567")]
            [MyAspect]
            public void MyMethod()
            {
                MyMethod(new Dictionary<string, string>());
            }
    
            public void MyMethod(Dictionary<string, string> values)
            {
                //Do work
            }
    
        }
    
        [Serializable]
        public class MyAspect : MethodInterceptionAspect
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            MethodInfo target;
    
            public override void CompileTimeInitialize(System.Reflection.MethodBase method, AspectInfo aspectInfo)
            {
                target = method.DeclaringType.GetMethod(method.Name, new Type[] { typeof(Dictionary<string, string>) });
    
                foreach (Attribute a in method.GetCustomAttributes(false))
                {
                    if (a is SpecialAttribute)
                    {
                        values.Add(((SpecialAttribute)a).Key, ((SpecialAttribute)a).Value);
                    }
                }
            }
    
            public override void OnInvoke(MethodInterceptionArgs args)
            {
                if (values == null || values.Count < 1)
                {
                    args.Proceed();
                }
                else
                {
                    target.Invoke(args.Instance, new object[] { values });
                }
                
            }
        }
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true) ]
        public class SpecialAttribute : Attribute
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
