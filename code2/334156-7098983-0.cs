    using System;
    using System.Linq.Expressions;
    
    class Person
    {
        public DateTime DateOfBirth { get; set; }
    }
    
    public class Test
    {
        static void Main()
        {
            Expression<Func<Person, DateTime>> expression = p => p.DateOfBirth;
            
            MemberExpression memberExpression = (MemberExpression) expression.Body;
            Console.WriteLine(memberExpression.Type); // Prints System.DateTime
        }    
    }
