    var letters = new List<string> { "A", "B", "C", "O", "Ä", "Ö" };
    IComparer<string> comparer = new StringComparer();
    var orderedLetters = letters.OrderBy(x => comparer); // returns "A", "Ä", "B", "C", "O", "Ö"
    
    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
    
            var comparisonResult = string.Compare(x, y, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace);
            var areSameUnderlyingLetters = comparisonResult == 0;
    
            if (areSameUnderlyingLetters)
            {
                return string.Compare(x, y);
            }
    
            return comparisonResult;
        }
    }
