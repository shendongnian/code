    /// <summary>
        /// Checks the given string against a regular expression to see
        /// if it is a valid hertz measurement, which can be used
        /// by this formatter.
        /// </summary>
        /// <param name="value">The string value to be tested</param>
        /// <returns>Returns true, if it is a valid hertz value</returns>
    private Boolean IsValidValue(String value)
    {
        //Regular Expression Explaination
        //
        //Start                                                                     (^)
        //Negitive numbers allowed                                                  (-?)
        //At least 1 digit                                                          (\d+)
        //Optional (. followed by at least 1 digit)                                 ((\.\d+)?)
        //Optional (optional whitespace + (any number of characters                 (\s?(([h].*)?([k].*)?([m].*)?([g].*)?([t].*)?)+)?
        //  of which must contain atleast one of the following letters (h,k,m,g,t))
        //  before the remainder of the string.
        //End                                                                       ($)
        String expression = @"^-?\d+(\.\d+)?(\s?(([h].*)?([k].*)?([m].*)?([g].*)?([t].*)?)+)?$";
        return Regex.IsMatch(value, expression, RegexOptions.IgnoreCase);
    }
