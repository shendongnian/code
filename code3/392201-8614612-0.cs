    List<A> ax = /* ... */;
    List<B> bx = /* ... */;
    List<C> cx = /* ... */;
    /* ... */
    IEnumerable<Tuple<int, int, object>> ratingsAndVotes =
        ax.Select((a) => Tuple.Create(a.Rating, a.Vote, a)).Concat(
        bx.Select((b) => Tuple.Create(b.Rating, b.Vote, b)).Concat(
        cx.Select((c) => Tuple.Create(c.Rating, c.Vote, c)) /* ... */;
    Tuple<int, int, object>[] topTenItems = 
        ratingsAndVotes.OrderByDescending((i) => i.Item1).ThenByDescending((i) => i.Item2).Take(10).ToArray();
    // topTenItems now contains the top 10 items out of all the lists;
    // for each tuple element, Item1 = rating, Item2 = vote,
    // Item3 = original list item (as object)
