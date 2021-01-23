    /// <summary>
    /// Visual Basic like operator. Performs simple, case insensitive, string pattern matching.
    /// </summary>
    /// <param name="thisString"></param>
    /// <param name="pattern"> ? = Any single character. * = Zero or more characters. # = Any single digit (0–9)</param>
    /// <returns>true if the string matches the pattern</returns>
    public static bool Like(this string thisString, string pattern)
        => Microsoft.VisualBasic.CompilerServices.Operators
            .LikeString(thisString, pattern, Microsoft.VisualBasic.CompareMethod.Text);
        
