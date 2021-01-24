    PropertyInfo propertyInfo = null;
    propertyInfo = propertySelectorExpression.Body switch // <-- noticed the switched order
    {
        MemberExpression me => me.Member as PropertyInfo,
        UnaryExpression ue => (ue.Operand as MemberExpression)?.Member as PropertyInfo
    }
