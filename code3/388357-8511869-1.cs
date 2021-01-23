    string ExtractNumericCharacters(string s)
    {
        IEnumerable<char> numericChars = s.Where(char.IsDigit);
        // numericChars is a Linq iterator; if you call ToString() on this object, you'll get the type name.
        // there's no string constructor or StringBuilder Append overload that takes an IEnumerable<char>
        // so we need to get a char[].  The ToArray() method iterates over the WhereEnumerator, copying
        // the sequence into a new array; this is functionally equivalent to using a foreach loop with an if statement.
        char[] numericCharArray = numericChars.ToArray();
        // now we can make a string!
        return new string(numericCharArray);
    }
