    public string GetSetting(Expression<Func<NotificationOptions, string>> selector)
    {
        string value = selector(_notificationSettings.Value);
        if (string.IsNullOrWhiteSpace(value))
        {
            var expression = (MemberExpression)selector;
            throw new Exception($"{expression.Member.Name} is not configured");
        }
        return value;
    }
