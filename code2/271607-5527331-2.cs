    // Not sure what to call the "n:n" groupings.  Assume
    // original is in an ArrayList named "pairs".
    IEnumerable<string> sortedPairs =
        from pair in pairs.Cast<string>()
        let parts = pair.Split(':')
        let parsed = new { 
            Left = Int32.Parse(parts[0]), 
            Right = Int32.Parse(parts[1]),
        }
        orderby parsed.Left descending, parsed.Right
        select pair;
