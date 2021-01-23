    using System;
    using System.Text.RegularExpression;
    private bool ContainOnlyDigits (string input)
    {
        bool containsNumbers = true;
        if (!Regex.IsMatch(input, @"/d"))
        {
            containsNumbers = false;
        }
        return contrainsNumbers;
    }
