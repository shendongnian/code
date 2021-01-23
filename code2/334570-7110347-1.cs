        /// <summary>
        /// Takes a string and and inserts a spacer character at 
        /// a specifed distance from the end
        /// </summary>
        /// <param name="input">string to modify</param>
        /// <param name="spacer">string to insert</param>
        /// <param name="positionFromEnd">insertion point</param>
        /// <returns></returns>
        protected string AddSpacer(string input, string spacer, int positionFromEnd)
        {
            string outputString = string.Empty;
            if (input.Length >= positionFromEnd)
            {
                outputString = input.Insert(input.Length - positionFromEnd, spacer);
            }
            else
            {
                throw new Exception("The position you tried to insert the spacer into doesn't exist");
            }
            return outputString;
        }
