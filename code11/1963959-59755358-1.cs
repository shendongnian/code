    public string GetSetting(Expression<Func<NotificationOptions, string>> selector)
    {
        Func<NotificationOptions, string> func = selector.Compile();
        string value = selector(_notificationSettings.Value);
        if (string.IsNullOrWhiteSpace(value))
        {
            var expression = (MemberExpression)selector.Body;
            throw new Exception($"{expression.Member.Name} is not configured");
        }
        return value;
    }
