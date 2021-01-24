    public enum EnumerationTest
    {
        A, B, C
    }
    public class ClassTest
    {
        public EnumerationTest Test { get; set; }
    }
    public static Expression PropertyExpression()
    {
       // Think of this like a lambda (p) => p.Test == Enumeration.A
       var parameter = Expression.Parameter(typeof(ClassTest), "p"); 
       var property = Expression.PropertyOrField(parameter, "Test");
       var constant = Expression.Constant(EnumerationTest.A, typeof(EnumerationTest));
       return Expression.Equal(property, constant);
    }
