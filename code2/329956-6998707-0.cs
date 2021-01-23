    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    
    public class Person
    {
        public string FirstName { get; set; }
    }
    
    static class Program
    {
        static void Main(string[] args)
        {
            string name = "Michael";
            
            Expression<Func<Person, object>> exp = p => p.FirstName == name;
            
            new Visitor().Visit(exp);
        }
    }
    
    class Visitor : ExpressionVisitor    
    {
        protected override Expression VisitMember
            (MemberExpression member)
        {
            if (member.Expression is ConstantExpression &&
                member.Member is FieldInfo)
            {
                object container = 
                    ((ConstantExpression)member.Expression).Value;
                object value = ((FieldInfo)member.Member).GetValue(container);
                Console.WriteLine("Got value: {0}", value);
            }
            return base.VisitMember(member);
        }
    }
