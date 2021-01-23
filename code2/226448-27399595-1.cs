    public static class ConsoleUtility
    {
    	/// <summary>
    	/// Converts a List of string arrays to a string where each element in each line is correctly padded.
    	/// Make sure that each array contains the same amount of elements!
    	/// - Example without:
    	/// Title Name Street
    	/// Mr. Roman Sesamstreet
    	/// Mrs. Claudia Abbey Road
    	/// - Example with:
    	/// Title   Name      Street
    	/// Mr.     Roman     Sesamstreet
    	/// Mrs.    Claudia   Abbey Road
    	/// <param name="lines">List lines, where each line is an array of elements for that line.</param>
    	/// <param name="padding">Additional padding between each element (default = 1)</param>
    	/// </summary>
    	public static string PadElementsInLines(List<string[]> lines, int padding = 1)
    	{
    		// Calculate maximum numbers for each element accross all lines
    		var numElements = lines[0].Length;
    		var maxValues = new int[numElements];
    		for (int i = 0; i < numElements; i++)
    		{
    			maxValues[i] = lines.Max(x => x[i].Length) + padding;
    		}
    		var sb = new StringBuilder();
    		// Build the output
    		bool isFirst = true;
    		foreach (var line in lines)
    		{
    			if (!isFirst)
    			{
    				sb.AppendLine();
    			}
    			isFirst = false;
    			for (int i = 0; i < line.Length; i++)
    			{
    				var value = line[i];
    				// Append the value with padding of the maximum length of any value for this element
    				sb.Append(value.PadRight(maxValues[i]));
    			}
    		}
    		return sb.ToString();
    	}
    }
