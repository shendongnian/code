    using System.Linq;
    using System.Data.Entity.SqlServer;
    using System.Linq.Expressions;
    using static System.Linq.Expressions.Expression;
    using System;
    
    namespace ToStringRewriting {
        class ToStringRewriter : ExpressionVisitor {
            static MethodInfo stringConvertMethodInfo = typeof(SqlFunctions).GetMethods()
                     .Single(x => x.Name == "StringConvert" && x.GetParameters()[0].ParameterType == typeof(decimal?));
            protected override Expression VisitMethodCall(MethodCallExpression node) {
                var method = node.Method;
                if (method.Name=="ToString") {
                    if (node.Object.GetType() == typeof(string)) { return node.Object; }
                    node = Call(stringConvertMethodInfo, Convert(node.Object, typeof(decimal?));
                }
                return base.VisitMethodCall(node);
            }
        }
        class Person {
            string Name { get; set; }
            long SocialSecurityNumber { get; set; }
        }
        class Program {
            void Main() {
                Expression<Func<Person, Boolean>> expr = x => x.ToString().Length > 1;
                var rewriter = new ToStringRewriter();
                var finalExpression = rewriter.Visit(expr);
                var dcx = new MyDataContext();
                var query = dcx.Persons.Where(finalExpression);
    
            }
        }
    }
