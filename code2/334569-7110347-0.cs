        /// <summary>
        /// Takes a string and and inserts a spacer character at 
        /// a specifed distance from the end
        /// </summary>
        /// <param name="input">string to modify</param>
        /// <param name="spacer">string to insert</param>
        /// <param name="positionFromEnd">insertion point</param>
        /// <returns></returns>
        string AddSpacer(string input, string spacer, int positionFromEnd)
        {
            return input.Insert(input.Length - positionFromEnd, spacer);
        }
