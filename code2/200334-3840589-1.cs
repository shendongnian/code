    [AttributeUsage(AttributeTargets.Property)]
    public class ExternallyVisible : Attribute
    {
    }
    public class MyWebControl
    {
        [ExternallyVisible]
        public string StyleString { get; set; }
    }
    public class SmarterWebControl : MyWebControl
    {
        [ExternallyVisible]
        public string CssName { get; set; }
        new public string StyleString { get; set; } // Doesn't work
    }
    class Program
    {
        static void Main()
        {
            MyWebControl myctrl = new MyWebControl();
            SmarterWebControl smartctrl = new SmarterWebControl();
            MemberInfo info = typeof(SmarterWebControl);
            PropertyInfo[] props = (typeof(SmarterWebControl)).GetProperties();
            Console.WriteLine("{0} properties", props.Length);
            foreach (var prop in props)
            {
                Console.WriteLine(prop.Name);
                foreach (var attr in prop.GetCustomAttributes(true))
                {
                    Console.WriteLine("  " + attr);
                }
            }
            Console.ReadLine();
        }
    }
