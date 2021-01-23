    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    namespace MyNameSpace
    {
        public static class AttributeHelper
        {
            public static TValue GetPropertyAttributeValue<T, TOut, TAttribute, TValue>(
                Expression<Func<T, TOut>> propertyExpression, 
                Func<TAttribute, TValue> valueSelector) 
                where TAttribute : Attribute
            {
                var expression = (MemberExpression)propertyExpression.Body;
                var propertyInfo = (PropertyInfo)expression.Member;
                var att = propertyInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
                return att != null ? valueSelector(att) : default(TValue);
            }
        }
    }
