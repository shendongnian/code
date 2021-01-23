    /// <summary>
        /// Returns a new string in which all occurrences of a specified string in the current instance are replaced with another 
        /// specified string acording the type of search to use for the specified string.
        /// </summary>
        /// <param name="str">The string performing the replace method.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string replace all occurrances of oldValue.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search. </param>
        /// <returns>A string that is equivalent to the current string except that all instances of oldValue are replaced with newValue.
        ///  If oldValue is not found in the current instance, the method returns the current instance unchanged. </returns>
        [DebuggerStepThrough()]//to prevent method from step-into (F11)
        public static string Replace(this string str,
            string oldValue, string @newValue,
            StringComparison comparisonType)
        {
            //Check inputs
            if (str == null)
            {
                //Same as original .NET C# string.Replace behaviour
                throw new ArgumentNullException(nameof(str));
            }
            if (str.Length == 0)
            {
                //Same as original .NET C# string.Replace behaviour
                return str;
            }
            if (oldValue == null)
            {
                //Same as original .NET C# string.Replace behaviour
                throw new ArgumentNullException(nameof(oldValue));
            }
            if (oldValue.Length == 0)
            {
                //Same as original .NET C# string.Replace behaviour
                throw new ArgumentException("String cannot be of zero length.");
            }
            //if (oldValue.Equals(newValue, comparisonType))
            //{
                //This condition has no sence
                //It will prevent method from replacesing: "Example", "ExAmPlE", "EXAMPLE" to "example"
                //return str;
            //}
            
            //Prepare replacment
            @newValue = @newValue ?? string.Empty;
            
            //Replace all values
            const int valueNotFound = -1;
            int foundAt, startSearchFromIndex = 0;
            while ((foundAt = str.IndexOf(oldValue, startSearchFromIndex, comparisonType)) != valueNotFound)
            {
                //Remove old value and insert new at the same place
                str = str.Remove(foundAt, oldValue.Length)
                    .Insert(foundAt, @newValue);
                //Prepare start index for the next search
                //This needed to prevent infinite loop, otherwise method always start search 
                //from the start of the string. So, if an oldValue == "EXAMPLE", newValue == "example"
                //and comparisonType == "any ignore case" will conquer to replacing:
                //"EXAMPLE" to "example" to "example" to "example" … infinite loop
                startSearchFromIndex = foundAt + @newValue.Length;
                if (startSearchFromIndex == str.Length)
                {
                    //End of the input string: no more space for the next search
                    break;
                }
            }
            return str;
        }
