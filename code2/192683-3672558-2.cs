    public class MyClass
    {
        public string MyStringProperty { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PropertyInfo propertyInfo = typeof(MyClass).GetProperty("MyStringProperty");
            Delegate getter = CreateGetter(propertyInfo);
            Delegate setter = CreateSetter(propertyInfo);
            object myClass = new MyClass();
            setter.DynamicInvoke(myClass, "Hello");
            Console.WriteLine(getter.DynamicInvoke(myClass));
        }
        public static Delegate CreateGetter(PropertyInfo property)
        {
            var objParm = Expression.Parameter(property.DeclaringType, "o");
            Type delegateType = typeof(Func<,>).MakeGenericType(property.DeclaringType, property.PropertyType);
            var lambda = Expression.Lambda(delegateType, Expression.Property(objParm, property.Name), objParm);
            return lambda.Compile();
        }
        public static Delegate CreateSetter(PropertyInfo property)
        {
            var objParm = Expression.Parameter(property.DeclaringType, "o");
            var valueParm = Expression.Parameter(property.PropertyType, "value");
            Type delegateType = typeof(Action<,>).MakeGenericType(property.DeclaringType, property.PropertyType);
            var lambda = Expression.Lambda(delegateType, Expression.Assign(Expression.Property(objParm, property.Name), valueParm), objParm, valueParm);
            return lambda.Compile();
        }
    }
