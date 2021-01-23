    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                using (var context = new NorthwindEntities())
                {
                    PropertyInfo propertyInfo = typeof(Customer).GetProperty("CustomerID"); 
    
                    IQueryable<Customer> query = context.Customers;
                    query = ETForStartsWith<Customer>(query, "A", propertyInfo); 
                    var list = query.ToList();
                }
            }
    
            static IQueryable<T> ETForStartsWith<T>(IQueryable<T> query, string propertyValue, PropertyInfo propertyInfo)
            {
                ParameterExpression e = Expression.Parameter(typeof(T), "e");
                MemberExpression m = Expression.MakeMemberAccess(e, propertyInfo);
                ConstantExpression c = Expression.Constant(propertyValue, typeof(string));
                MethodInfo mi = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
                Expression call = Expression.Call(m, mi, c);
                
                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(call, e); 
                return query.Where(lambda);
            }
        }
    }
