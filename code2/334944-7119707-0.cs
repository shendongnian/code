    static string ToCamelCaseInvariant(string value) { return ToCamelCase(value, true, CultureInfo.InvariantCulture); }
    static string ToCamelCaseInvariant(string value, bool changeWordCaps) { return ToCamelCase(value, changeWordCaps, CultureInfo.InvariantCulture); }
    static string ToCamelCase(string value) { return ToCamelCase(value, true, CultureInfo.CurrentCulture); }
    static string ToCamelCase(string value, bool changeWordCaps) { return ToCamelCase(value, changeWordCaps, CultureInfo.CurrentCulture); }
    /// <summary>
    /// Converts the given string value into camelCase.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="changeWordCaps">If set to <c>true</c> letters in a word (apart from the first) will be lowercased.</param>
    /// <param name="culture">The culture to use to change the case of the characters.</param>
    /// <returns>
    /// The camel case value.
    /// </returns>
    static string ToCamelCase(string value, bool changeWordCaps, CultureInfo culture)
    {
        if (culture == null)
            throw new ArgumentNullException("culture");
        if (string.IsNullOrEmpty(value))
            return value;
        var result = new StringBuilder(value.Length);
        var lastWasBreak = true;
        for (var i = 0; i < value.Length; i++)
        {
            var c = value[i];
            if (char.IsWhiteSpace(c) || char.IsPunctuation(c) || char.IsSeparator(c))
            {
                lastWasBreak = true;
            }
            else if (char.IsNumber(c))
            {
                result.Append(c);
                lastWasBreak = true;
            }
            else
            {
                if (result.Length == 0)
                {
                    result.Append(char.ToLower(c, culture));
                }
                else if (lastWasBreak)
                {
                    result.Append(char.ToUpper(c, culture));
                }
                else if (changeWordCaps)
                {
                    result.Append(char.ToLower(c, culture));
                }
                else
                {
                    result.Append(c);
                }
                lastWasBreak = false;
            }
        }
        return result.ToString();
    }
    // Tests
    '  This is a test. 12345hello world' = 'thisIsATest12345HelloWorld'
    '--north korea' = 'northKorea'
    '!nOrTH koreA' = 'northKorea'
    'System.Console.' = 'systemConsole'
