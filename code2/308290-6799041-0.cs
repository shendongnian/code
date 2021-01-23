    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.Linq.Expressions;
    using System.ComponentModel;
    using System.Reflection;
    namespace Test
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                List<Class1> foobars = new List<Class1>();
                foobars.Add(new Class1 { Foo = "Hello world!", Bar = -1, Skip = false, Ref = new Class2 { ToBe = true } });
                string result = foobars.ToCsv(",", Environment.NewLine, "\"", m => m.Foo, m => m.Bar, m => m.Ref.ToBe);
            }
            public class Class1
            {
                [DisplayName("Foo Property")]
                public string Foo { get; set; }
                public int Bar { get; set; }
                [DisplayName("Skipped Property")]
                public bool Skip { get; set; }
                [DisplayName("Reference")]
                public Class2 Ref { get; set; }
            }
            public class Class2
            {
                [DisplayName("To Be or Not To Be")]
                public bool ToBe { get; set; }
            }
        }
        public static class Extensions
        {
            public static string ToCsv<TModel>(this List<TModel> list, string delimiter, string lineBreak, string valueWrap, params Expression<Func<TModel, object>>[] expressions)
            {
                var sb = new StringBuilder();
                var headers = expressions.Select(m => String.Format("{0}{1}{0}", valueWrap, GetDisplayName(m))).ToArray();
                sb.Append(String.Format("{0}{1}", String.Join(delimiter, headers), lineBreak));
                foreach (var listItem in list)
                {
                    var values = expressions.Select(m => String.Format("{0}{1}{0}", valueWrap, m.Compile()(listItem))).ToArray();
                    sb.Append(String.Format("{0}{1}", String.Join(delimiter, values), lineBreak));
                }
                return sb.ToString();
            }
            // Get DisplayName, otherwise fallback to Name
            private static string GetDisplayName(LambdaExpression memberReference)
            {
                MemberInfo info = GetMemberInfo(memberReference);
                DisplayNameAttribute displayNameAttr = Attribute.GetCustomAttribute(info, typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                return (displayNameAttr != null ? displayNameAttr.DisplayName : info.Name);
            }
            // Can be swapped for your favourite GetMemberInfo/GetPropertyInfo utility method (there are many out there)
            // Source: http://blog.baltrinic.com/software-development/dotnet/extension-methods-for-converting-lambda-expression-to-strings
            private static MemberInfo GetMemberInfo(LambdaExpression memberReference)
            {
                MemberExpression memberExpression;
                var unary = memberReference.Body as UnaryExpression;
                if (unary != null)
                    //In this case the return type of the property was not object,
                    //so .Net wrapped the expression inside of a unary Convert()
                    //expression that casts it to type object. In this case, the
                    //Operand of the Convert expression has the original expression.
                    memberExpression = unary.Operand as MemberExpression;
                else
                    //when the property is of type object the body itself is the
                    //correct expression
                    memberExpression = memberReference.Body as MemberExpression;
                if (memberExpression == null || !(memberExpression.Member is MemberInfo))
                    throw new ArgumentException("Expression was not of the form 'x => x.member'.");
                return memberExpression.Member;
            }
        }
    }
