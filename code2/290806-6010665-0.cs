    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace q6010555
    {
        class Program
        {
            static void Main(string[] args)
            {
                int one = 1;
                var result = GetVarNameAndValue(() => one);
            }
    
            static KeyValuePair<string, x> GetVarNameAndValue<x>(Expression<Func<x>> expr)
            {
                var lambda = expr as LambdaExpression;
                var body = lambda.Body;
                var field = body as MemberExpression;
                var name = field.Member.Name;
                var constant = field.Expression as ConstantExpression;
                var value = (x)((field.Member as FieldInfo).GetValue(constant.Value));
                return new KeyValuePair<string, x>(name, value);
            }
        }
    }
