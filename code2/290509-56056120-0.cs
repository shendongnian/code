    {(x.Children.Count(y => y.SomeID == SomeVar) > 0)}
using System;
using System.Linq;
using System.Linq.Expressions;
namespace ExpressionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterExpression foundX = Expression.Parameter(typeof(Parent), "x");
            Guid[] guids = new Guid[1] { Guid.NewGuid() };
            Expression expression = GetCountWithPredicateExpression(guids, foundX);
        }
        private static Expression GetCountWithPredicateExpression(Guid[] idsToFilter, ParameterExpression foundX)
        {
            System.Reflection.PropertyInfo childIDPropertyInfo = typeof(Child).GetProperty(nameof(Child.SomeID));
            ParameterExpression foundY = Expression.Parameter(typeof(Child), "y");
            Expression childIDLeft = Expression.Property(foundY, childIDPropertyInfo);
            Expression conditionExpression = Expression.Constant(false, typeof(bool));
            foreach (Guid id in idsToFilter)
                conditionExpression = Expression.Or(conditionExpression, Expression.Equal(childIDLeft, Expression.Constant(id)));
            Expression<Func<Child, bool>> idLambda = Expression.Lambda<Func<Child, bool>>(conditionExpression, foundY);
            var countMethod = typeof(Enumerable).GetMethods()
                .First(method => method.Name == "Count" && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(Child));
            System.Reflection.PropertyInfo childrenPropertyInfo = typeof(Parent).GetProperty("Children");
            Expression childrenLeft = Expression.Property(foundX, childrenPropertyInfo);
            Expression ret = Expression.GreaterThan(Expression.Call(countMethod, childrenLeft, idLambda), Expression.Constant(0));
            return ret;
        }
    }
    public class Parent
    {
        public Child[] Children { get; set; }
    }
    public class Child
    {
        public int ID { get; set; }
        public Guid SomeID { get; set; }
    }
}
