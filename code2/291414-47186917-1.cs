    /// <summary>
    /// Extension method to find/replace replaces text in a StringBuilder object
    /// </summary>
    /// <param name="original">Source StringBuilder object</param>
    /// <param name="oldString">String to search for</param>
    /// <param name="newString">String to replace each occurrance of oldString</param>
    /// <param name="stringComparison">String comparison to use</param>
    /// <returns>Original Stringbuilder with replacements made</returns>
    public static StringBuilder Replace(this StringBuilder original,
                        string oldString, string newString, StringComparison stringComparison)
        {
            //If anything is null, or oldString is blank, exit with original value
            if ( newString == null || original == null || string.IsNullOrEmpty(oldString))
                return original;
            //Convert to a string and get starting position using
            //IndexOf which allows us to use StringComparison.
            int pos = original.ToString().IndexOf(oldString, 0, stringComparison);
            //Loop through until we find and replace all matches
            while ( pos >= 0 )
            {
                //Remove the old string and insert the new one.
                original.Remove(pos, oldString.Length).Insert(pos, newString);
                //Get the next match starting 1 character after last replacement (to avoid a possible infinite loop)
                pos = original.ToString().IndexOf(oldString, pos + newString.Length + 1, stringComparison);
            }
            return original;
        }
