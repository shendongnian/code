    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    namespace ConsoleApplication3
    {
        public class MyClass
        {
            public int IntegralValue { get; set; }
    
            public void Validate()
            {
                if (this.IntegralValue < 0)
                    throw new ArgumentOutOfRangeException(PropertyHelper.GetName<MyClass>(o => o.IntegralValue));
            }
        }
    
        public static class PropertyHelper
        {
            /// <summary>Extracts the property (member) name from the provided expression.</summary>
            public static string GetName<T>(this Expression<Func<T, object>> expression)
            {
                MemberExpression memberExpression = null;
    
                if (expression.Body is MemberExpression)
                    memberExpression = (MemberExpression)expression.Body;
                else if (expression.Body is UnaryExpression)
                    memberExpression = (((UnaryExpression)expression.Body).Operand as MemberExpression);
    
                if (memberExpression == null)
                    throw new ApplicationException("Could not determine member name from expression.");
    
                return memberExpression.Member.Name;
            }
        }
    
        public static class Program
        {
            public static void Main(string[] args)
            {
                MyClass good = new MyClass() { IntegralValue = 100 };
                MyClass bad = new MyClass() { IntegralValue = -100 };
    
                try { good.Validate(); }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
    
                try { bad.Validate(); }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
    
                Console.ReadKey();
            }
        }
    }
