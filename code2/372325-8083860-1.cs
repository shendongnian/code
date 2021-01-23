    // for each combination of ID1 and ID2
    // return the latest item from the 
    // most frequently-occuring quantity
    IEnumerable<MyEntity> GetLatestMaxByID(IEnumerable<MyEntity> list) {
        foreach (var group in list.GroupBy(x => new { x.ID1, x.ID2 }))
            yield return GetSingleItemForIDs(group);
    }
    // return the latest item from the 
    // most frequently-occuring quantity
    MyEntity GetSingleItemForIDs(IEnumerable<MyEntity> list) {
        return list.GroupBy(x => x.Quantity)
                   .MaxBy(g => g.Count())
                   .MaxBy(x => x.Date);
    }
    // use MaxBy from the morelinq (http://code.google.com/p/morelinq) 
    // or use a simplified one here
    // Get the maximum item based on a key
    public static T MaxBy<T, U>(this IEnumerable<T> seq, Func<T, U> f) {
        return seq.Aggregate((a, b) => Comparer<U>.Default.Compare(f(a), f(b)) < 0 ? b : a);
    }
