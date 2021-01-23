    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    namespace ConsoleApplication2
    {
        class MyClass
        {
            public int I { get; set; }
            public string S { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                HashSet<MyClass> hs = new HashSet<MyClass>(new SamePublicPropertiesInstance());
                
                MyClass x = new MyClass();
                x.I = 1;
                x.S = "1";
                hs.Add(x);
                MyClass y = new MyClass();
                y.I = 2;
                y.S = "1";
                hs.Add(y);
                MyClass z = new MyClass();
                z.I = 2;
                z.S = "1";
                hs.Add(z);
                foreach (MyClass m in hs)
                {
                    Console.WriteLine("I: {0} S: {1}", m.I, m.S);
                }
                Console.ReadLine();
            }
        }
    }
    class SamePublicPropertiesInstance : EqualityComparer<object>
    {
        public override bool Equals(object o1, object o2)
        {
            PropertyInfo[] pInfos = o1.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            string pName;
            bool equal;
            MethodInfo methodInfo;
            
            foreach (PropertyInfo pInfo in pInfos)
            {
                pName = pInfo.Name.ToString();
                methodInfo = o1.GetType().GetProperty(pName).GetGetMethod();
                equal = methodInfo.Invoke(o1, null).ToString() 
                        == 
                        methodInfo.Invoke(o2, null).ToString();
                if (!equal) return false;
            }
            return true;
        }
        public override int GetHashCode(object o)
        {
            return 1.GetHashCode();
        }
    }
