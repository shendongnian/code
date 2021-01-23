        /// <summary>
        /// Recursively searches the supplied AD string for all groups.
        /// </summary>
        /// <param name="data">The string returned from AD to parse for a group.</param>
        /// <param name="delimiter">The string to use as the seperator for the data. ex. ","</param>
        /// <returns>null if no groups were found -OR- data is null or empty.</returns>
        public static List<string> Parse(string data, string delimiter)
        {
            if (data == null) return null;
            if (!delimiter.EndsWith("=")) delimiter = delimiter + "=";
            //data = data.ToUpper(); // why did i add this?
            if (!data.Contains(delimiter)) return null;
            //base case
            var result = new List<string>();
            int start = data.IndexOf(delimiter) + 3;
            int length = data.IndexOf(',', start) - start;
            if (length == 0) return null; //the group is empty
            if (length > 0)
            {
                result.Add(data.Substring(start, length));
                //only need to recurse when the comma was found, because there could be more groups
                var rec = Parse(data.Substring(start + length), delimiter);
                if (rec != null) result.AddRange(rec); //can't pass null into AddRange() :(
            }
            else //no comma found after current group so just use the whole remaining string
            {
                result.Add(data.Substring(start));            
            }
            return result;
        }
