    /// <summary>Returns the Excel-style name of the column from the column index.</summary>
    /// <param name="colIndex">The column index.</param>
    static string GetColumnName(int colIndex)
    {
        if (colIndex < 1)
            throw new ArgumentException("Column number must be greater or equal to 1.");
        var result = new List<char>();
        //letter codes start at Chr(65)'
        while (colIndex > 0)
        {
            //reduce the column number by 1 else the 26th column (Z) will become 0 (@) 
            //add 65 to the result and find the Chr() value.
            //insert the character at position 0 of the char list
            //integer divide the column index by 26 to remove the last calculated column 
            //from the stack and repeat till  there are no columns in the stack.                                       
            result.Insert(0, Microsoft.VisualBasic.Strings.Chr(65 + Convert.ToInt32((colIndex - 1) % 26)));
            colIndex = (int)((colIndex-1)/ 26);
        }
        return new string(result.ToArray());
    }
