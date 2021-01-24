    class Program
    {
        static void Main(string[] args)
        {
            var lambda = LambdaExpressionWithParameters();
            MyClass1 c1 = new MyClass1() { Name = "Hans" };
            MyClass2 c2 = new MyClass2() { Name = "Peter", Value = 42 };
            var b1 = lambda.DynamicInvoke(c1);
            var b2 = lambda.DynamicInvoke(c2);
        }
        static Delegate LambdaExpressionWithParameters()
        {
            ParameterExpression pex = Expression.Parameter(typeof(IMyInterface));//IMyInterface as Parameter 
            ConstantExpression cex = Expression.Constant("Peter");//Constant "Peter"
            MemberExpression mex = Expression.PropertyOrField(pex, "Name");//Property Name of IMyInterface
            BinaryExpression bex = Expression.Equal(mex, cex);
            return Expression.Lambda(bex, pex).Compile();
        }
    }
    class MyClass1 : IMyInterface
    {
        public string Name { get; set; }
    }
    class MyClass2 : IMyInterface
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
    public interface IMyInterface
    {
        string Name { get; set; }
    }
