     public static string GetPropertyDisplayString<T>(Expression<Func<T, object>> propertyExpression)
        {
            var memberInfo = GetPropertyInformation(propertyExpression.Body);
            if (memberInfo == null)
            {
                throw new ArgumentException(
                    "No property reference expression was found.",
                    "propertyExpression");
            }
            var displayAttribute = memberInfo.GetAttribute<DisplayAttribute>(false);
            if (displayAttribute != null)
            {
                return displayAttribute.Name;
            }
            else
            {
                var displayNameAttribute = memberInfo.GetAttribute<DisplayNameAttribute>(false);
                if (displayNameAttribute != null)
                {
                    return displayNameAttribute.DisplayName;
                }
                else
                {
                    return memberInfo.Name;
                }
            }
        }
