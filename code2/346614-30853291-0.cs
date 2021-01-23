        using System;
        using System.Collections.Generic;
        using System.Linq;
        /// <summary>
        /// Returns a string with the specified characters removed.
        /// </summary>
        /// <param name="source">The string to filter.</param>
        /// <param name="removeCharacters">The characters to remove.</param>
        /// <returns>A new <see cref="System.String"/> with the specified characters removed.</returns>
        public static string Remove(this string source, IEnumerable<char> removeCharacters)
        {
            if (source == null)
            {
                throw new  ArgumentNullException("source");
            }
            if (removeCharacters == null)
            {
                throw new ArgumentNullException("removeCharacters");
            }
            // First see if we were given a collection that supports ISet
            ISet<char> replaceChars = removeCharacters as ISet<char>;
            if (replaceChars == null)
            {
                replaceChars = new HashSet<char>(removeCharacters);
            }
            IEnumerable<char> filtered = source.Where(currentChar => !replaceChars.Contains(currentChar));
            return new string(filtered.ToArray());
        }
