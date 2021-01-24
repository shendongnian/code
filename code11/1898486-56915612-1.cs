    public string Replace(string input, string find, string replace)
    {
        // The current index in the string where we are searching from
        int currIndex = 0;
        // The index of the next substring to replace
        int index = input.IndexOf(find);
        // A string builder used to build the new string
        var builder = new StringBuilder();
        // Continue until the substring is not found
        while(index != -1)
        {
            // If the current index is not equal to the substring location
            // when we need to append everything from the current position
            // to where we found the substring
			if(index != currIndex ) 
            {
                builder.Append(input.Substring(currIndex , index - currIndex));
            }
            // Now append the replacement
            builder.Append(replace);
            // Move the current position past the found substring
            currIndex = index + find.Length;
            // Search for the next substring.
            index = input.IndexOf(find, currIndex );
        }
   
        // If the current position is not the end of the string we need
        // to append the remainder of the string.
        if(currIndex < input.Length) 
        {
            builder.Append(input.Substring(currIndex));
        }
        return builder.ToString();
    }
