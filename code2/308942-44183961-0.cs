    // Input: "HELLO     BEAUTIFUL       WORLD!"
    private string NormalizeWhitespace(string inputStr)
    {
        // First split the string on the spaces but exclude the spaces themselves
        // Using the input string the length of the array will be 3. If the spaces
        // were not filtered out they would be included in the array
        var splitParts = inputStr.Split(' ').Where(x => x != "").ToArray();
       // Now iterate over the parts in the array and add them to the return
       // string. If the current part is not the last part, add a space after.
       for (int i = 0; i < splitParts.Count(); i++)
       {
            retVal += splitParts[i];
            if (i != splitParts.Count() - 1)
            {
                retVal += " ";
            }
       }
        return retVal;
    }
    // Would return "HELLO BEAUTIFUL WORLD!"
