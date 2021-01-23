    public class MyClass
    {
        public string MyStringProperty { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Delegate dgt = CreateGetter(typeof(MyClass).GetProperty("MyStringProperty"));
            object myClass = new MyClass { MyStringProperty = "Hello" };
            Console.WriteLine(dgt.DynamicInvoke(myClass));
        }
        public static Delegate CreateGetter(PropertyInfo property)
        {
            var objParm = Expression.Parameter(property.DeclaringType, "o");
            Type delegateType = typeof(Func<,>).MakeGenericType(property.DeclaringType, property.PropertyType);
            var lambda = Expression.Lambda(delegateType, Expression.Property(objParm, property.Name), objParm);
            return lambda.Compile();
        }
    }
