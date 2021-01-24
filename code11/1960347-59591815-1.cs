    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    public static class ObjectExtensions
    {
        public static K GetDefaultValue<T, K>(this T obj, Expression<Func<T, K>> exp)
        {
            var info = ((MemberExpression)exp.Body).Member;
            return (K)(TypeDescriptor.GetProperties(info.DeclaringType)[info.Name]
                .Attributes.OfType<DefaultValueAttribute>()
                .FirstOrDefault()?.Value ?? default(K));
        }
    }
