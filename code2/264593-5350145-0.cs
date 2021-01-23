    using System;
    using System.Dynamic;
    namespace ConsoleApplication1
    {
        class DynamicParts : System.Dynamic.DynamicObject
        {
            private string[] m_Values;
            public DynamicParts(string values)
            {
                this.m_Values = values.Split('*');
            }
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                var index = Convert.ToInt32(binder.Name.Replace("Value", ""));
                result = m_Values[index - 1];
                return true;
            }
            public static void Main()
            {
                dynamic d = new DynamicParts("value1*value2*value3*value4");
                Console.WriteLine(d.Value1);
                Console.WriteLine(d.Value2);
                Console.WriteLine(d.Value3);
                Console.WriteLine(d.Value4);
                Console.ReadLine();
            }
        }
    }
