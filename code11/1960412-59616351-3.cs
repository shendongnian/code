    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    public class Program
    {
        static void Main(string[] args)
        {
            var test = new {Foo = "bar"};
            var test2 = new {Foo = "derp"};
    
            // get the annonymous type
            Type anonType = test.GetType();
    
            // create a list of that annonymous type
            IList genericList = (IList) Activator.CreateInstance(typeof(List<>).MakeGenericType(anonType));
            
            genericList.Add(test);
            genericList.Add(test2);
    
            // Find the correct Enumerable.Where method
            MethodInfo whereMethod = typeof(Enumerable).GetMethods().Single(m =>
            {
                if (m.Name != "Where" || !m.IsStatic)
                    return false;
                ParameterInfo[] parameters = m.GetParameters();
                return parameters.Length == 2 && parameters[1].ParameterType.GetGenericArguments().Length == 2;
            });
    
            // construct the finalmethod using generic type
            MethodInfo finalMethod = whereMethod.MakeGenericMethod(anonType);
    
            // define the Type of the Filter Func<anontype,bool>
            Type filterType = typeof(Func<,>).MakeGenericType(anonType, typeof(bool));
    
    
            // Build a simple filter expression
            // this is mostly to subsitute for the missing packages you are using to create that filter func
            ParameterExpression parameter = Expression.Parameter(anonType, "item");
            MemberExpression member = Expression.Property(parameter, "Foo");
            BinaryExpression euqalExpression = Expression.Equal(member, Expression.Constant("derp"));
    
            LambdaExpression filterExpression = Expression.Lambda(filterType, euqalExpression, parameter);
            Delegate filter = filterExpression.Compile();
            Console.WriteLine("This is the Filter: {0}", filterExpression);
            
            // Finally invoke and see it in action
            IEnumerable result = (IEnumerable) finalMethod.Invoke(null, new object[] {genericList, filter});
    
            foreach (dynamic o in result)
            {
                Console.WriteLine(o.Foo);
            }
    
            Console.ReadKey();
        }
    }
