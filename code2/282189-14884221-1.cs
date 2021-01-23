    public static string AddSpacesToMixedCaseString(string strInput)
    {
        string strOutput = "";
        int intCharPos = 0;
        int intLastCharPos = strInput.Length - 1;
        // for every character in the input string
        for (intCharPos = 0; intCharPos <= intLastCharPos; intCharPos++)
        {
            char chrInput = strInput[intCharPos];
            // Put a space before each upper case character if it is not the first character
            if (char.IsUpper(chrInput) == true && intCharPos > 0)
            {
                strOutput += " ";
            } // end if
            // Add the character from the input string to the output string
            strOutput += chrInput;
        } // Next
        
        return strOutput;
    } // end method
