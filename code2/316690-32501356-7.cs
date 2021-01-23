    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    public static class AttributeHelper
    {
        public static TValue GetPropertyAttributeValue<T, TOut, TAttribute, TValue>(
            Expression<Func<T, TOut>> propertyExpression, 
            Func<TAttribute, TValue> valueSelector) 
            where TAttribute : Attribute
        {
            var expression = (MemberExpression) propertyExpression.Body;
            var propertyInfo = (PropertyInfo) expression.Member;
            var attr = propertyInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            return attr != null ? valueSelector(attr) : default(TValue);
        }
    }
