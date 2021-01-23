    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    class Program
    {
        internal class MyClass
        {
            public string MyProperty { get; set; }
        }
        static void Main(string[] args)
        {
            foreach (var mi in
                    typeof(MyClass).GetMembers(BindingFlags.NonPublic | BindingFlags.Instance)
                        .Where(m => m is FieldInfo))
            {
                Debug.WriteLine(mi.Name);
            }
            MyClass o = new MyClass();
            var fi = (FieldInfo)typeof(MyClass).GetMember(
                "<MyProperty>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic)[0];
            fi.SetValue(o, "Success");
            Debug.WriteLine(o.MyProperty);
        }
    }
