    override bool IsValid(object value) {
        this.SetupRegex();
        // Convert the value to a string
        string stringValue = Convert.ToString(value, CultureInfo.CurrentCulture);
        // Automatically pass if value is null or empty. RequiredAttribute should be used to assert a value is not empty.
        if (String.IsNullOrEmpty(stringValue)) {
            return true;
        }
        Match m = this.Regex.Match(stringValue);
        // We are looking for an exact match, not just a search hit. This matches what
        // the RegularExpressionValidator control does
        return (m.Success && m.Index == 0 && m.Length == stringValue.Length);
    } 
