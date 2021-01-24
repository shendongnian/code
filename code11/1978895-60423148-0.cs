    private string _text;
    public string Text
    {
        get => _text;
        set
        {
            if (IsValid(value))
            {
                _text = value;
            }
            else
            {
                ValidationErrors.Add("'abcd' was expected.");
            }
        }
    }
    private bool IsValid<T>(T value, [CallerMemberName] string propertyName = null)
    {
        switch (propertyName)
        {
            case nameof(Text):
                return value as string == "abcd";
            default:
                throw new ArgumentOutOfRangeException(nameof(propertyName), propertyName, null);
        }
    }
    public static class ValidationErrors
    {
        public static void Add(string message, [CallerMemberName] string propertyName = null)
        {
            throw new NotImplementedException();
        }
    }
