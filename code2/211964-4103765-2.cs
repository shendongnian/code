    /// <summary>
    /// Example code for how <see cref="int.TryParse(string,out int)"/> might be implemented.
    /// </summary>
    /// <param name="integerString">A string to convert to an integer.</param>
    /// <param name="result">The result of the parse if the operation was successful.</param>
    /// <returns>true if the <paramref name="integerString"/> parameter was successfully 
    /// parsed into the <paramref name="result"/> integer; false otherwise.</returns>
    public bool TryParse(string integerString, out int result)
    {
    	try
    	{
    		result = int.Parse(integerString);
    		return true;
    	}
    	catch (OverflowException)
    	{
    		// Handle a number that was correctly formatted but 
    		// too large to fit into an Int32.
    	}
    	catch (FormatException)
    	{
    		// Handle a number that was incorrectly formatted 
    		// and so could not be converted to an Int32.
    	}
    
    	result = 0; // Default.
    	return false;
    }
