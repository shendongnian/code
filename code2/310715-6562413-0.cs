    class User
    {
        public int Age { get; set; }
        public string UserName { get; set; }
    }
    class Operator
    {
        private static Dictionary<string, Func<object, object, bool>> s_operators;
        private static Dictionary<string, PropertyInfo> s_properties;
        static Operator()
        {
            s_operators = new Dictionary<string, Func<object, object, bool>>();
            s_operators["greater_than"] = new Func<object, object, bool>(s_opGreaterThan);
            s_operators["equal"] = new Func<object, object, bool>(s_opEqual);
            s_properties = typeof(User).GetProperties().ToDictionary(propInfo => propInfo.Name);
        }
        public static bool Apply(User user, string op, string prop, object target)
        {
            return s_operators[op](GetPropValue(user, prop), target);
        }
        private static object GetPropValue(User user, string prop)
        {
            PropertyInfo propInfo = s_properties[prop];
            return propInfo.GetGetMethod(false).Invoke(user, null);
        }
        #region Operators
        static bool s_opGreaterThan(object o1, object o2)
        {
            if (o1 == null || o2 == null || o1.GetType() != o2.GetType() || !(o1 is IComparable))
                return false;
            return (o1 as IComparable).CompareTo(o2) > 0;
        }
        static bool s_opEqual(object o1, object o2)
        {
            return o1 == o2;
        }
        //etc.
        #endregion
        public static void Main(string[] args)
        {
            User user = new User() { Age = 16, UserName = "John" };
            Console.WriteLine(Operator.Apply(user, "greater_than", "Age", 15));
            Console.WriteLine(Operator.Apply(user, "greater_than", "Age", 17));
            Console.WriteLine(Operator.Apply(user, "equal", "UserName", "John"));
            Console.WriteLine(Operator.Apply(user, "equal", "UserName", "Bob"));
        }
    }
