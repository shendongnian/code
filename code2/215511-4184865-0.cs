    delegate string StringAggregateDelegate(string, string);
    
    static string AggregateDelegate(string workingSentence, string next)
    {
        return next + " " + workingSentence;
    }
    
    static string Aggregate(IEnumerable source,
                            StringAggregateDeletate AggregateDelegate)
    {
        // start enumerating the source;
        IEnumerator e = source.GetEnumerator();
        // return empty string if the source is empty
        if (!e.MoveNext())
            return "";
        // get first element as our base case
        string workingSentence = (string)e.Current;
        // call delegate on each item after the first one
        while (e.MoveNext())
            workingSentence = AggregateDelegate(workingSentence, (string)e.Current);
        // return the result
        return workingSentence;
    }
    // now use the Aggregate function:
        string[] words = sentence.Split(' ');
        // Prepend each word to the beginning of the
        // new sentence to reverse the word order.
        string reversed = Aggregate(words,
                                    new StringAggregateDelegate(AggregateDelegate));
