    using System;
    using System.Linq.Expressions;
    
    public class Person
    {
        public DateTime DateOfBirth { get; set; }
    }
    
    public class Test
    {
        static void Main()
        {
            var expr = Foo<Person>("DateOfBirth", "1976");
    
            Person p = new Person
            {
                DateOfBirth = new DateTime(1976, 6, 19)
            };
            
            Console.WriteLine(expr.Compile()(p));
        }
        
        static Expression<Func<T, bool>> Foo<T>(string propertyName,
                                                string searchValue)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            Expression property = Expression.Property(parameter, propertyName);
            Expression toStringCall = Expression.Call(
                property, "ToString",
                null,
                new[] { Expression.Constant("D") });
            
            Expression containsCall = Expression.Call(
                toStringCall, "Contains",
                null,
                new[] { Expression.Constant(searchValue) });
            
            return Expression.Lambda<Func<T, bool>>(containsCall, parameter);
        }
    }
