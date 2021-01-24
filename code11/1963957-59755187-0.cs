public string GetSetting(Func<NotificationOptions, string> selector)
{
    string value = selector(_notificationSettings.Value);
    if (string.IsNullOrWhiteSpace(value))
    {
        throw new Exception("Not configured");
    }
    return value;
}
And call it like:
GetSetting(x => x.AssignReminderTemplateCode);
