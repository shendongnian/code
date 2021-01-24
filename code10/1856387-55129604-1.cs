    protected string GetStringSafely(string name, CultureInfo culture)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        var keyCulture = culture ?? CultureInfo.CurrentUICulture;
        //..
    }
