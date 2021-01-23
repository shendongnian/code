        /// <summary>
        /// Parse the input string by placing a space between character case changes in the string
        /// </summary>
        /// <param name="strInput">The string to parse</param>
        /// <returns>The altered string</returns>
        public static string ParseByCase(string strInput)
        {
            // The altered string (with spaces between the case changes)
            string strOutput = "";
            // The index of the current character in the input string
            int intCurrentCharPos = 0;
            // The index of the last character in the input string
            int intLastCharPos = strInput.Length - 1;
            // for every character in the input string
            for (intCurrentCharPos = 0; intCurrentCharPos <= intLastCharPos; intCurrentCharPos++)
            {
                // Get the current character from the input string
                char chrCurrentInputChar = strInput[intCurrentCharPos];
                // At first, set previous character to the current character in the input string
                char chrPreviousInputChar = chrCurrentInputChar;
                
                // If this is not the first character in the input string
                if (intCurrentCharPos > 0)
                {
                    // Get the previous character from the input string
                    chrPreviousInputChar = strInput[intCurrentCharPos - 1];
                } // end if
                // Put a space before each upper case character if the previous character is lower case
                if (char.IsUpper(chrCurrentInputChar) == true && char.IsLower(chrPreviousInputChar) == true)
                {   
                    // Add a space to the output string
                    strOutput += " ";
                } // end if
                // Add the character from the input string to the output string
                strOutput += chrCurrentInputChar;
            } // next
            
            // Return the altered string
            return strOutput;
        } // end method
