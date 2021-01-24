Besides needing ThenBy, you also need to remember that OrderBy isn't in place but returns an ordered IEnumerable
    public class ClassXY
    {
        public string Position;
    }
    ObservableCollection<ClassXY> _myCollection = new ...;
    var orderedCollection = 
          myCollection.OrderBy(p => p.Position)
                      .ThenBy(p => Convert.ToDouble(p.Position));
Just as an FYI, OrderBy and ThenBy also come as OrderByDescending and ThenByDescending so you don't have to negate a condition and sacrifice readability for simple descending ordering.
